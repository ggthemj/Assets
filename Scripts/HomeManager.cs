using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using System;

public class HomeManager : SceneController {

	public static HomeManager instance;
	GameObject header;
	GameObject collectionZone;
	GameObject officialGame;
	GameObject friendlyGame;
	GameObject statistiques;
	public int page;

	// Use this for initialization
	void Start () {
		instance=this;
		this.page = 0;
		base.status = 0;
		AppModel.instance.setSceneController(this);
		this.header = GameObject.Find("Header");
		this.collectionZone = GameObject.Find("CollectionZone");
		this.officialGame = GameObject.Find("OfficialGame");
		this.friendlyGame = GameObject.Find("FriendlyGame");
		this.statistiques = GameObject.Find("Statistiques");
		this.initTexts();
		this.updateAll();
		this.resize();
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
	}

	public override void initTexts(){
		
	}

	public override void resume(string error){
		if(base.status==1){
			if(error.Equals("")){
				
			}
			else{
				
			}
		}
		AppModel.instance.loadingScreen.hideLoading();
	}

	public void pushHelp(){
		//TBC
	}

	public void quitGame(){
		//TBC
	}

	public void hitParameters(){
		//TBC
	}

	public void showColliders(bool b){
		this.header.GetComponent<HomeHeaderController>().showColliders(b);
		this.collectionZone.GetComponent<CollectionZoneController>().showColliders(b);
		this.officialGame.GetComponent<OfficialGameZoneController>().showColliders(b);
		this.friendlyGame.GetComponent<FriendlyGameZoneController>().showColliders(b);
		this.statistiques.GetComponent<StatsZoneController>().showColliders(b);
	}

	public void resize(){
		this.header.GetComponent<HomeHeaderController>().resize();
		this.collectionZone.GetComponent<CollectionZoneController>().resize();
		this.officialGame.GetComponent<OfficialGameZoneController>().resize();
		this.friendlyGame.GetComponent<FriendlyGameZoneController>().resize();
		this.statistiques.GetComponent<StatsZoneController>().resize();
	}

	public HomeHeaderController getHeader(){
		return this.header.GetComponent<HomeHeaderController>();
	}

	public CollectionZoneController getCollection(){
		return this.collectionZone.GetComponent<CollectionZoneController>();
	}

	public void updateAll(){
		this.getHeader().updateHeader();
		this.getCollection().updateCards(this.page);
		this.officialGame.GetComponent<OfficialGameZoneController>().updateInfos();
		this.friendlyGame.GetComponent<FriendlyGameZoneController>().updateInfos();
		this.statistiques.GetComponent<StatsZoneController>().updateInfos();
	}

	public void jouerOfficiel(){
		AppModel.instance.isFriendly = false;
		AppModel.instance.launchGame();
	}

	public void jouerAmicalOfficiel(){
		AppModel.instance.isFriendly = true;
		if(AppModel.instance.isOnline){
			AppModel.instance.launchGame();
		}
		else{
			this.launchPregame();
		}
	}

	public void launchPregame(){
		SceneManager.LoadScene("Pregame");
	}
}
