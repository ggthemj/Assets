using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using System;

public class AuthentManager : SceneController {

	public static AuthentManager instance;
	GameObject loginUI;
	int toggle;
	string login, mdp;

	// Use this for initialization
	void Start () {
		instance=this;
		this.login = "";
		this.mdp = "";
		base.status = 0;
		AppModel.instance.setSceneController(this);
		this.loginUI = GameObject.Find("LoginUI");

		this.initTexts();
		this.showBackgroundPopUp(false);
		this.showLoginUI(false);
		this.initLoginUI();

		if(PlayerPrefs.HasKey("RememberMe")){
			this.toggle = PlayerPrefs.GetInt("RememberMe");
		}
		else{
			this.toggle = 0;
			PlayerPrefs.SetInt("RememberMe",this.toggle);
		}

		this.loginUI.transform.FindChild("Toggle").GetComponent<ToggleButtonController>().setSprite(this.toggle);
		this.showBackgroundPopUp(true);
		this.showLoginUI(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(AppModel.instance.loadingScreen.toShowLoading){
			AppModel.instance.loadingScreen.addTime(Time.deltaTime);
		}
	}

	void showLoginUI(bool b){
		this.loginUI.SetActive(b);
	}

	void initLoginUI(){
		this.loginUI.transform.FindChild("LoginInput").GetComponent<TMP_InputField>().caretWidth=0;
	}

	public override void initTexts(){
		this.loginUI.transform.FindChild("LoginTitle").GetComponent<TextMeshProUGUI>().text = AppModel.instance.getWording(0);
		this.loginUI.transform.FindChild("LoginInput").FindChild("Text Area").FindChild("Placeholder").GetComponent<TextMeshProUGUI>().text = AppModel.instance.getWording(1);
		this.loginUI.transform.FindChild("LoginPassword").FindChild("Text Area").FindChild("Placeholder").GetComponent<TextMeshProUGUI>().text = AppModel.instance.getWording(2);
		this.loginUI.transform.FindChild("TitleToggle").GetComponent<TextMeshProUGUI>().text = AppModel.instance.getWording(3);
		this.loginUI.transform.FindChild("Connect").GetComponent<ConnectButtonController>().setText(AppModel.instance.getWording(4));
	}

	void showBackgroundPopUp(bool b){
		GameObject.Find("BackgroundPopUp").GetComponent<SpriteRenderer>().enabled = b;
	}

	public void launchHome(){
		Debug.Log("Test connection");
		base.status = 1 ;
		if(Application.platform==RuntimePlatform.WindowsEditor){
			if(!PlayerPrefs.HasKey("NeedSync")){
				PlayerPrefs.SetInt("NeedSync",0);
			}
			if(PlayerPrefs.GetInt("NeedSync")==1){
				//TBC
			}
			else{
				AppModel.instance.getPlayerData("testor");
			}
		}
		else{
			//TBC
		}
		Debug.Log("connection terminée");
	}

	public void hitToggle(){
		if(this.toggle==0){
			this.toggle=1;
		}
		else{
			this.toggle=0;
		}
		PlayerPrefs.SetInt("RememberMe",this.toggle);
		this.loginUI.transform.FindChild("Toggle").GetComponent<ToggleButtonController>().setSprite(this.toggle);
	}

	public override void resume(string error){
		if(base.status==1){
			if(error.Equals("")){
				base.moveToScene("Home");
			}
			else{
				Debug.Log("ErreurConnection "+error);
			}
		}
	}
}
