using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class AppModel : MonoBehaviour 
{
	public int languageID ;
	public RuntimePlatform runtimePlatform ;
	public static AppModel instance;
	SceneController sceneController;
	public bool isOnline;
	public string hash = "J8xy9Uz4";

	public LoadingScreen loadingScreen;
	public UserDataModel userData;
	string login ;
	public int widthScreen;
	public int heightScreen;

	void Awake(){
		instance = this;
		this.isOnline = true;
		this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
		this.widthScreen = Screen.width;
		this.heightScreen = Screen.height;
		DontDestroyOnLoad(gameObject.transform);

		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://techtical-wars.firebaseio.com");
	}

	void Start(){
		if(PlayerPrefs.HasKey("LanguageID")){
			this.languageID = PlayerPrefs.GetInt("LanguageID");
		}
		else{
			this.languageID = 0;
			PlayerPrefs.SetInt("LanguageID",0);
		}
		this.runtimePlatform = Application.platform;
		SceneManager.LoadScene("Authent");
		this.isOnline = true;
	}

	public string getWording(int idReference){
		return WordingBackOffice.getText(idReference, this.languageID);
	}

	public string getUnlockText(int idReference){
		return CardStatsData.getUnlockText(idReference, this.languageID);
	}

	public string getCardNameText(int idReference){
		return CardStatsData.getNameText(idReference, this.languageID);
	}

	public int getLifeCard(int idReference, int level){
		return CardStatsData.getLife(idReference, level);
	}

	public int getMoveCard(int idReference, int level){
		return CardStatsData.getMove(idReference, level);
	}

	public string getErrorWording(int idReference){
		return WordingBackOffice.getErrorText(idReference, this.languageID);
	}

	public string getWording(int idReference, List<int> args){
		return WordingBackOffice.getText(idReference, args, this.languageID);
	}

	public void changeLanguage(){
		this.languageID++;
		if(this.languageID>1){
			this.languageID=0;
		}
		this.sceneController.initTexts();
	}

	public void setSceneController(SceneController sceneC){
		this.sceneController = sceneC;
	}

	public void getPlayerData(string login){
		this.loadingScreen.showLoading();
		FirebaseDatabase.DefaultInstance.GetReference("users").Child(login).GetValueAsync().ContinueWith(task => {
			if (task.IsCanceled){
				Debug.Log("Task has been canceled");
			}
	        else if (task.IsFaulted) {
	        	Debug.Log("ERREUR "+task.Exception.ToString());
				this.sceneController.resume(task.Exception.ToString());
	        }
	        else if (task.IsCompleted) {
	        	DataSnapshot snapshot = task.Result;
				if(snapshot.HasChild("credits")){
					this.fillUserDataWithJson(snapshot);
					this.sceneController.resume("");
	         	}
	         	else{
					this.sceneController.resume(AppModel.instance.getErrorWording(0));
	         	}
	        }
	  	});
	}

	public void fillUserDataWithJson(DataSnapshot snapshot){
		this.userData = JsonUtility.FromJson<UserDataModel>(snapshot.GetRawJsonValue());
		this.userData.cards = new List<CardModel>();
		for (int i = 0 ; i < 12 ; i++){
			this.userData.cards.Add(JsonUtility.FromJson<CardModel>(snapshot.Child("card"+i).GetRawJsonValue()));
		}
	}

	public void testConnection(){
		//TBC
	}
}