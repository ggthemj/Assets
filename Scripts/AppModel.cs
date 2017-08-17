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
	public BigCardController bigCard;
	public PopUpValidationController popUp;
	public TrainingCardController training;

	public UserDataModel userData;
	string login ;
	public int widthScreen;
	public int heightScreen;
	SkillData[] skillsData;
	public int status;
	public int popUpStatus;
	public int popUpStatusNo;
	public bool isFriendly;

	public Sprite[] skillSprites;
	public Sprite[] bigCharacterSprites;
	public Sprite[] backgroundCards;
	public Sprite[] characters;

	void Awake(){
		instance = this;
		this.isOnline = true;
		this.isFriendly = false;
		this.status = 0;
		this.popUpStatus = 0;
		this.popUpStatusNo = 0;
		this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
		this.bigCard = GameObject.Find("CardModification").GetComponent<BigCardController>();
		this.bigCard.initTexts();
		this.popUp = GameObject.Find("PopUpValidation").GetComponent<PopUpValidationController>();
		this.training = GameObject.Find("PopUpTraining").GetComponent<TrainingCardController>();
		this.training.initTexts();
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
		this.initSkillData();
	}

	public void initSkillData(){
		this.skillsData = new SkillData[48];
		for(int i = 0 ; i < 48 ; i++){
			this.skillsData[i] = new SkillData();
		}
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

	public string getSkillNameText(int id){
		return skillsData[id].getName(this.languageID);
	}

	public string getSkillDescription(int skillId, int level){
		return skillsData[skillId].getDescription(level, this.languageID);
	}

	public string getSkillBonus(int skillId, int level){
		return skillsData[skillId].getBonus(level, this.languageID);
	}

	public string getBonus(int cardId, int carac, int level){
		return CardStatsData.getBonus(carac, level, cardId);
	}

	public int getPrice(int carac, int levelmax, int startinglevel){
		return CardStatsData.getPrice(carac, levelmax, startinglevel);
	}

	public string getErrorWording(int idReference){
		return WordingBackOffice.getErrorText(idReference, this.languageID);
	}

	public string getWording(int idReference, List<int> args){
		return WordingBackOffice.getText(idReference, args, this.languageID);
	}

	public string getWording(int idReference, List<string> args){
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

	public Sprite getSkillSprite(int id){
		return this.skillSprites[id];
	}

	public Sprite getBigCharacterSprite(int id){
		return this.bigCharacterSprites[id];
	}

	public Sprite getCardBackground(int id){
		return this.backgroundCards[id];
	}

	public Sprite getCharacter(int id){
		return this.characters[id];
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
					this.userData.fillPlayerPrefs();

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
		this.userData.fillCards();
	}

	public void testConnection(){
		if(this.isOnline){
			HomeManager.instance.showColliders(false);
			this.popUpStatus = 3;
			this.popUpStatusNo = 2;
			this.popUp.launch(true, AppModel.instance.getWording(49), AppModel.instance.getWording(51), AppModel.instance.getWording(32), AppModel.instance.getWording(52));
			this.popUp.show(true);
		}
		else{
			HomeManager.instance.showColliders(false);
			this.popUpStatus = 4;
			this.popUpStatusNo = 3;
			this.popUp.launch(true, AppModel.instance.getWording(48), AppModel.instance.getWording(50), AppModel.instance.getWording(53), AppModel.instance.getWording(54));
			this.popUp.show(true);
		}
	}

	public void hitBigCardSkill(int id){
		this.bigCard.showColliders(false);
		this.training.idCard = this.bigCard.idCard;
		this.training.indexCarac = id;

		this.training.updateInfos();
		this.training.show(true);
	}

	public void hitYesButton(){
		if(this.popUpStatus==1){
			HomeManager.instance.updateAll();
			this.bigCard.updateValues();
			this.training.updateInfos();
			this.training.show(true);
			this.popUp.show(false);
		}
		else if(this.popUpStatus==2){
			this.training.showColliders(true);
			this.popUp.show(false);
		}
		else if(this.popUpStatus==3){
			PlayerPrefs.SetInt("toSync",1);
			this.isOnline = false;
			HomeManager.instance.getHeader().switchConnectionButton();
			this.popUp.show(false);
			HomeManager.instance.updateAll();
			HomeManager.instance.showColliders(true);
		}
		else if(this.popUpStatus==4){
			this.loadingScreen.showLoading();
			this.popUp.show(false);
			this.SyncFromLocal();
		}
		else if(this.popUpStatus==5){
			HomeManager.instance.showColliders(true);
			this.popUp.show(false);
		}
	}

	public void SyncFromLocal(){
		AppModel.instance.userData.reverseFillCards();
		string json = JsonUtility.ToJson(AppModel.instance.userData);
		FirebaseDatabase.DefaultInstance.GetReference("users").Child(AppModel.instance.userData.name).SetRawJsonValueAsync(json).ContinueWith(task => {
			if(task.IsFaulted){
				Debug.Log("Erreur "+task.Exception.ToString());
				this.popUpStatus=5;
				this.popUp.launch(false, AppModel.instance.getWording(55), AppModel.instance.getWording(56), AppModel.instance.getWording(32), "");
				this.popUp.show(true);
				this.loadingScreen.hideLoading();
			}
			else if(task.IsCompleted){
				PlayerPrefs.SetInt("toSync",0);
				this.isOnline = true;
				HomeManager.instance.showColliders(true);
				HomeManager.instance.updateAll();
				HomeManager.instance.getHeader().switchConnectionButton();
				this.loadingScreen.hideLoading();
			}
		});
	}

	public void hitNoButton(){
		if(this.popUpStatusNo==1){
			//TBC
		}
		else if(this.popUpStatusNo==2){
			this.popUp.show(false);
			HomeManager.instance.showColliders(true);	
		}
		else if(this.popUpStatusNo==3){
			this.loadingScreen.showLoading();
			this.popUp.show(false);
			this.SyncFromOnline();	
		}
	}

	public void SyncFromOnline(){
		FirebaseDatabase.DefaultInstance.GetReference("users").Child(AppModel.instance.userData.name).GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
	        	Debug.Log("ERREUR "+task.Exception.ToString());
				this.popUpStatus=5;
				this.popUp.launch(false, AppModel.instance.getWording(55), AppModel.instance.getWording(56), AppModel.instance.getWording(32), "");
				this.popUp.show(true);
				this.loadingScreen.hideLoading();
	        }
	        else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
				this.fillUserDataWithJson(snapshot);
				PlayerPrefs.SetInt("toSync",0);
				this.isOnline = true;
				HomeManager.instance.updateAll();
				HomeManager.instance.showColliders(true);
				HomeManager.instance.getHeader().switchConnectionButton();

				this.loadingScreen.hideLoading();
	        }
	  	});
	}

	public void hitNotEnoughMoney(){
		this.popUpStatus = 2;
		this.popUpStatusNo = 1;
		this.training.showColliders(false);
		this.popUp.launch(true, AppModel.instance.getWording(43), AppModel.instance.getWording(44), AppModel.instance.getWording(32), AppModel.instance.getWording(45));
		this.popUp.show(true);
	}

	public void hitCagnotte(){
		//TBC
	}

	public void hitMagasin(){
		//TBC
	}

	public void hitLeftButton(){
		this.training.indexCarac--;
		if(this.training.indexCarac<0){
			this.training.indexCarac = 5;
		}
		this.training.show(false);
		this.training.updateInfos();
		this.training.show(true);
	}

	public void hitRightButton(){
		this.training.indexCarac++;
		if(this.training.indexCarac>5){
			this.training.indexCarac = 0;
		}
		this.training.show(false);
		this.training.updateInfos();
		this.training.show(true);
	}

	public void hitLeftBCButton(){
		this.bigCard.idCard--;
		if(this.bigCard.idCard<0){
			this.bigCard.idCard = CardStatsData.getNumberOfCards()-1;
		}

		while(AppModel.instance.userData.cards[this.bigCard.idCard].skill1==0){
			this.bigCard.idCard--;
			if(this.bigCard.idCard<0){
				this.bigCard.idCard = CardStatsData.getNumberOfCards()-1;
			}
		}
		this.bigCard.show(false);
		this.bigCard.updateValues();
		this.bigCard.show(true);
	}

	public void hitRightBCButton(){
		this.bigCard.idCard++;
		if(this.bigCard.idCard==CardStatsData.getNumberOfCards()){
			this.bigCard.idCard = 0;
		}

		while(AppModel.instance.userData.cards[this.bigCard.idCard].skill1==0){
			this.bigCard.idCard++;
			if(this.bigCard.idCard==CardStatsData.getNumberOfCards()){
				this.bigCard.idCard = 0;
			}
		}
		this.bigCard.show(false);
		this.bigCard.updateValues();
		this.bigCard.show(true);
	}

	public void hitCBButton(){
		this.bigCard.show(false);
		HomeManager.instance.showColliders(true);
	}

	public void hitCBBCButton(){
		this.training.show(false);
		this.bigCard.showColliders(true);
	}

	public void hitCBHomeButton(){
		this.training.show(false);
		this.bigCard.show(false);
		HomeManager.instance.showColliders(true);
	}

	public void buySkill(int id){
		this.training.showColliders(false);
		this.loadingScreen.showLoading();
		int ancienLevel = AppModel.instance.userData.cards[this.training.idCard].getCarac(this.training.indexCarac);
		int newLevel = AppModel.instance.userData.cards[this.training.idCard].getCarac(this.training.indexCarac)+Mathf.Max(1,id);
		AppModel.instance.userData.cards[this.training.idCard].setCarac(this.training.indexCarac, newLevel);
		PlayerPrefs.SetInt("card"+this.training.idCard+"_"+this.training.indexCarac, newLevel);
						
		if(this.isOnline){
			FirebaseDatabase.DefaultInstance.GetReference("users").Child(AppModel.instance.userData.name).Child("card"+this.training.idCard+"_"+this.training.indexCarac).SetValueAsync(newLevel).ContinueWith(task => {
				if(task.IsFaulted){
					Debug.Log("Erreur "+task.Exception.ToString());
					PlayerPrefs.SetInt("toSync",1);
					this.isOnline = false;
					HomeManager.instance.getHeader().switchConnectionButton();
					this.removeCristals(AppModel.instance.getPrice(this.training.indexCarac,newLevel,ancienLevel),true, newLevel);
				}
				else if(task.IsCompleted){
					this.removeCristals(AppModel.instance.getPrice(this.training.indexCarac,newLevel,ancienLevel),false, newLevel);
				}
			});
		}
		else{
			this.removeCristals(AppModel.instance.getPrice(this.training.indexCarac,newLevel,ancienLevel),false, newLevel);
		}
	}

	public void removeCristals(int nb, bool error, int newLevel){
		AppModel.instance.userData.credits-=nb;
		PlayerPrefs.SetInt("credits", AppModel.instance.userData.credits);
		HomeManager.instance.updateAll();
		this.bigCard.updateValues();
		this.training.updateInfos();

		if(error){
			this.loadingScreen.hideLoading();
			this.popUp.launch(false, AppModel.instance.getWording(46), AppModel.instance.getWording(47), AppModel.instance.getWording(32), "");
			this.popUp.show(true);
		}
		else if(this.isOnline){
			FirebaseDatabase.DefaultInstance.GetReference("users").Child(AppModel.instance.userData.name).Child("credits").SetValueAsync(AppModel.instance.userData.credits).ContinueWith(task => {
				if(task.IsFaulted){
					Debug.Log("Erreur "+task.Exception.ToString());
					PlayerPrefs.SetInt("toSync",1);
					this.isOnline = false;
					HomeManager.instance.getHeader().switchConnectionButton();
					this.loadingScreen.hideLoading();
					this.popUp.launch(false, AppModel.instance.getWording(46), AppModel.instance.getWording(47), AppModel.instance.getWording(32), "");
					this.popUp.show(true);
				}
				else if(task.IsCompleted){
					this.popUpStatus = 1;
					if(this.training.indexCarac>1){
						this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(31, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), AppModel.instance.getSkillNameText(4*this.training.idCard+this.training.indexCarac-2), ""+newLevel}), AppModel.instance.getWording(32) , "");
					}
					else if(this.training.indexCarac==1){
						this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(33, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), ""+AppModel.instance.getLifeCard(this.training.idCard, AppModel.instance.userData.cards[this.training.idCard].life)}), AppModel.instance.getWording(32), "");
					}
					else{
						this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(34, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), ""+AppModel.instance.getMoveCard(this.training.idCard, AppModel.instance.userData.cards[this.training.idCard].move)}), AppModel.instance.getWording(32), "");
					}	
					this.loadingScreen.hideLoading();
				}
			});
		}
		else{
			this.loadingScreen.hideLoading();
			this.popUpStatus = 1;
			if(this.training.indexCarac>1){
				this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(31, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), AppModel.instance.getSkillNameText(4*this.training.idCard+this.training.indexCarac-2), ""+newLevel}), AppModel.instance.getWording(32) , "");
			}
			else if(this.training.indexCarac==1){
				this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(33, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), ""+AppModel.instance.getLifeCard(this.training.idCard, AppModel.instance.userData.cards[this.training.idCard].life)}), AppModel.instance.getWording(32), "");
			}
			else{
				this.launchConfirmation(false, AppModel.instance.getWording(30), AppModel.instance.getWording(34, new List<string>(){CardStatsData.getNameText(this.training.idCard, this.languageID), ""+AppModel.instance.getMoveCard(this.training.idCard, AppModel.instance.userData.cards[this.training.idCard].move)}), AppModel.instance.getWording(32), "");
			}		
		}
	}

	public void launchConfirmation(bool b, string title, string description, string buttonYes, string buttonNo){
		this.popUp.launch(b, title, description, buttonYes, buttonNo);
		this.popUp.show(true);
	}

	public void launchError(){

	}

	public void endBuySkill(){
		this.loadingScreen.hideLoading();
		this.training.showColliders(false);
	}

	public void clickSmallCard(int id){
		HomeManager.instance.showColliders(false);
		this.bigCard.idCard = HomeManager.instance.page*12+id;
		this.bigCard.updateValues();
		this.bigCard.showColliders(true);
		this.bigCard.show(true);
	}

	public void launchGame(){
		HomeManager.instance.showColliders(false);
		this.loadingScreen.showLoading();			
		FirebaseDatabase.DefaultInstance.GetReference("users").Child(AppModel.instance.userData.name).Child("haslaunchedgame").SetValueAsync(1).ContinueWith(task => {
			if(task.IsFaulted){
				Debug.Log("Erreur "+task.Exception.ToString());
				PlayerPrefs.SetInt("toSync",1);
				this.isOnline = false;
				HomeManager.instance.getHeader().switchConnectionButton();

				if(AppModel.instance.isFriendly){
					AppModel.instance.userData.haslaunchedgame = 1;
					PlayerPrefs.SetInt("haslaunchedgame", 1);
					HomeManager.instance.launchPregame();
				}
				else{
					this.popUpStatus = 5;
					this.launchConfirmation(false, AppModel.instance.getWording(46), AppModel.instance.getWording(73), AppModel.instance.getWording(32) , "");
				}
			}
			else if(task.IsCompleted){
				AppModel.instance.userData.haslaunchedgame = 1;
				PlayerPrefs.SetInt("haslaunchedgame", 1);
				HomeManager.instance.launchPregame();
			}
		});
	}
}