using System;
using UnityEngine;
using TMPro;

public class HomeHeaderController:MonoBehaviour
{
	public Sprite[] icons;

	void Start(){
		this.resize();
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
		gameObject.transform.Find("RightHeaderDesktop").FindChild("HelpButton").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("RightHeaderDesktop").FindChild("ConnectionButton").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("LeftHeaderDesktop").FindChild("QuitButton").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("LeftHeaderDesktop").FindChild("ParametersButton").GetComponent<BoxCollider2D>().enabled = b;
	}

	public void showMobileColliders(bool b){

	}

	public void showDesktop(bool b){
		
	}

	public void updateHeader(){
		gameObject.transform.Find("RightHeaderDesktop").FindChild("CristalCount").GetComponent<TextMeshPro>().text = AppModel.instance.userData.credits.ToString();
		gameObject.transform.Find("RightHeaderDesktop").FindChild("NamePlayer").GetComponent<TextMeshPro>().text = AppModel.instance.userData.name;
		gameObject.transform.Find("RightHeaderDesktop").FindChild("IconPlayer").GetComponent<SpriteRenderer>().sprite = this.icons[AppModel.instance.userData.iconid];
	}

	public void resize(){
		float w = AppModel.instance.widthScreen;
		float h = AppModel.instance.heightScreen;
		if(AppModel.instance.widthScreen>AppModel.instance.heightScreen){
			gameObject.transform.Find("LeftHeaderDesktop").position = new Vector3((-1*((10f*w/h)/2f-(520f/216f)-0.1f)),4.35f,0f);
			gameObject.transform.Find("RightHeaderDesktop").position = new Vector3((+1*((10f*w/h)/2f-(0.75f*762f/216f)-0.1f)),4.35f,0f);
		}
	}

	public void switchConnectionButton(){
		gameObject.transform.Find("RightHeaderDesktop").FindChild("ConnectionButton").GetComponent<ConnectionButtonController>().updateSprite();
	}
}