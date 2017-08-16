using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class FriendlyGameZoneController:MonoBehaviour
{
	public Sprite[] Grads;

	void Start(){
		this.resize();
		this.initTexts();
	}

	public void initTexts(){
		gameObject.transform.Find("TitleZone").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(58);
		gameObject.transform.Find("Jouer").GetComponent<JouerAmicalButtonController>().setText(AppModel.instance.getWording(62));
		gameObject.transform.Find("OfflineText").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(67);
	}

	public void showColliders(bool b){
		if(AppModel.instance.widthScreen>AppModel.instance.heightScreen){
	 		this.showDesktopColliders(b);
	 	}
	 	else{
	 		this.showMobileColliders(b);
		}
	}

	public void showDesktopColliders(bool b){
		gameObject.transform.Find("Jouer").GetComponent<JouerButtonController>().GetComponent<BoxCollider2D>().enabled = b;
	}

	public void showMobileColliders(bool b){

	}

	public void showDesktop(bool b){
		
	}

	public void resize(){
		float w = AppModel.instance.widthScreen;
		float h = AppModel.instance.heightScreen;
		if(AppModel.instance.widthScreen>AppModel.instance.heightScreen){
			gameObject.transform.localPosition = new Vector3((0.33f*((10f*w/h))),-0.6f,0f);
			gameObject.transform.Find("Background").localScale = new Vector3((1*(1080f*0.32f*w/h)),290f,0f);
			gameObject.transform.Find("TitleZone").localPosition = new Vector3(0f, 1.05f, 0f);
			gameObject.transform.Find("Jouer").localPosition = new Vector3(0f, -0.8f, 0f);
			gameObject.transform.Find("OfflineText").GetComponent<RectTransform>().sizeDelta = new Vector2(1f*((3f*w)/h), 1.2f);
		}
	}

	public void updateInfos(){
		
	}
}