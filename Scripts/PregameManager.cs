using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using System;

public class PregameManager : SceneController {

	public static PregameManager instance;
	public int displayedPm;
	GameObject team;
	List<int> unites;
	float timeMalus = 1f;
	float timerMalus ;
	bool toDisplayMalusTimer;
	bool[] toRotateCard;
	float[] timerRotation;
	float timeRotation = 0.8f;

	// Use this for initialization
	void Awake () {
		instance=this;
		AppModel.instance.loadingScreen.showLoading();
		this.toDisplayMalusTimer = false;
		AppModel.instance.setSceneController(this);
		this.toRotateCard=new bool[4];
		this.toRotateCard[0]=false;
		this.toRotateCard[1]=false;
		this.toRotateCard[2]=false;
		this.toRotateCard[3]=false;
		this.timerRotation=new float[4];
		this.timerRotation[0]=0f;
		this.timerRotation[1]=0f;
		this.timerRotation[2]=0f;
		this.timerRotation[3]=0f;
		this.unites = AppModel.instance.userData.getRandom4Units();
		this.team = GameObject.Find("TeamZone");
		this.initTexts();
		this.updateAll();
		this.resize();
		if(AppModel.instance.isFriendly){
			this.displayedPm = 20;
		}
		else{
			this.displayedPm = 10 ;
		}
		this.team.GetComponent<TeamZoneController>().displayTimer(this.displayedPm.ToString());
		AppModel.instance.loadingScreen.hideLoading();
	}
	
	// Update is called once per frame
	void Update () {
		if(AppModel.instance.loadingScreen.toShowLoading){
			AppModel.instance.loadingScreen.addTime(Time.deltaTime);
		}
		if(Screen.width!=AppModel.instance.widthScreen || Screen.height!=AppModel.instance.heightScreen){
			AppModel.instance.widthScreen = Screen.width;
			AppModel.instance.heightScreen = Screen.height;
			this.resize();
		}
		if(this.toDisplayMalusTimer){
			this.timerMalus += Time.deltaTime;
			if(this.timeMalus<=this.timerMalus){
				this.team.GetComponent<TeamZoneController>().showMalusTimer(false);
			}
			else{
				this.team.GetComponent<TeamZoneController>().setMalusTimerPosition(1f*timerMalus/timeMalus);
			}
		}
		for(int i = 0 ; i < 4 ; i++){
			if(this.toRotateCard[i]){
				this.timerRotation[i]+=Time.deltaTime;
				if(this.timerRotation[i]>this.timeRotation){
					this.toRotateCard[i]=false;
					this.team.GetComponent<TeamZoneController>().setCardPosition(i, 1f);
					this.team.GetComponent<TeamZoneController>().showSwitch(i,true);
					if (i > 0) {
						this.team.GetComponent<TeamZoneController> ().showForward (i, true);
					}
				}
				else{
					this.team.GetComponent<TeamZoneController>().setCardPosition(i, 1f*this.timerRotation[i]/this.timeRotation);
				}
			}
		}
	}

	public override void initTexts(){
		this.team.GetComponent<TeamZoneController>().initTexts();
	}

	public void showColliders(bool b){
		this.team.GetComponent<TeamZoneController>().showColliders(b);
	}

	public void resize(){
		this.team.GetComponent<TeamZoneController>().resize();
	}

	public void updateAll(){
		this.team.GetComponent<TeamZoneController>().updateCards();
	}

	public int getUnite(int i){
		return this.unites[i];
	}

	public void hitSwitch(int id){
		this.toRotateCard[id]=true;
		this.timerRotation[id]=0f;
		this.team.GetComponent<TeamZoneController>().toChangeCard[id]=true;
		this.unites[id]=AppModel.instance.userData.getRandomUnitLeft(this.unites);
		this.team.GetComponent<TeamZoneController>().showSwitch(id,false);
		this.displayedPm -= 5;
		this.team.GetComponent<TeamZoneController> ().setPMText (this.displayedPm.ToString ());
		this.team.GetComponent<TeamZoneController> ().showMalusTimer (true);
		if (this.displayedPm == 1) {
			this.team.GetComponent<TeamZoneController> ().changePMTitle ();
		}
		if (this.displayedPm < 5) {
			this.team.GetComponent<TeamZoneController> ().disableSwitchs ();
		}
		if (this.displayedPm < 2) {
			this.team.GetComponent<TeamZoneController> ().disableForwards ();
		}
		this.team.GetComponent<TeamZoneController> ().setMalusText ("-5 " + AppModel.instance.getWording (80));
		this.timerMalus = 0f;
		this.toDisplayMalusTimer = true;
	}

	public void hitForward(int id){
		this.toRotateCard[id]=true;
		this.toRotateCard[id-1]=true;
		this.timerRotation[id]=0f;
		this.timerRotation[id-1]=0f;
		this.team.GetComponent<TeamZoneController>().toChangeCard[id]=true;
		this.team.GetComponent<TeamZoneController>().toChangeCard[id-1]=true;
		int temp = this.unites [id];
		this.unites [id] = this.unites [id - 1];
		this.unites [id-1] = temp;
		this.team.GetComponent<TeamZoneController>().showSwitch(id,false);
		this.team.GetComponent<TeamZoneController>().showForward(id,false);
		this.team.GetComponent<TeamZoneController>().showSwitch(id-1,false);
		this.team.GetComponent<TeamZoneController> ().showMalusTimer (true);
		if (id > 1) {
			this.team.GetComponent<TeamZoneController>().showForward(id-1,false);
		}
		this.displayedPm -= 2;
		this.team.GetComponent<TeamZoneController> ().setPMText (this.displayedPm.ToString ());
		if (this.displayedPm == 1) {
			this.team.GetComponent<TeamZoneController> ().changePMTitle ();
		}
		if (this.displayedPm < 5) {
			this.team.GetComponent<TeamZoneController> ().disableSwitchs ();
		}
		if (this.displayedPm < 2) {
			this.team.GetComponent<TeamZoneController> ().disableForwards ();
		}
		this.team.GetComponent<TeamZoneController> ().setMalusText ("-2 " + AppModel.instance.getWording (80));
		this.timerMalus = 0f;
		this.toDisplayMalusTimer = true;
	}

	public void launchGame(){
		SceneManager.LoadScene ("Game");
	}
}
