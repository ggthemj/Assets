using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OfficialGameZoneController:MonoBehaviour
{
	public Sprite[] grads;

	void Start(){
		this.resize();
		this.initTexts();
	}

	public void initTexts(){
		gameObject.transform.Find("TitleZone").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(57);
		gameObject.transform.Find("Jouer").GetComponent<JouerButtonController>().setText(AppModel.instance.getWording(62));
		gameObject.transform.Find("OfflineText").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(66);
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
			gameObject.transform.localPosition = new Vector3((0.33f*((10f*w/h))),2.25f,0f);
			gameObject.transform.Find("Background").localScale = new Vector3((1*(1080f*0.32f*w/h)),290f,0f);
			gameObject.transform.Find("TitleZone").localPosition = new Vector3(0f, 1.05f, 0f);
			gameObject.transform.Find("Maintien").localPosition = new Vector3(-1*((1.6f*w)/h)+1.9f, -0.7f, 0f);
			gameObject.transform.Find("Montee").localPosition = new Vector3(-1*((1.6f*w)/h)+1.9f, -1.1f, 0f);
			gameObject.transform.Find("DivisionIcon").localPosition = new Vector3(1*((10f*w)/h)/9f, 0.7f, 0f);
			gameObject.transform.Find("Jouer").localPosition = new Vector3(-1*((10f*w)/h)/20f, 0.3f, 0f);
			gameObject.transform.Find("MatchsRestants").localPosition = new Vector3(0f, -0.35f, 0f);
			gameObject.transform.Find("OfflineText").GetComponent<RectTransform>().sizeDelta = new Vector2(1f*((3f*w)/h), 2f);
		}
	}

	public void updateInfos(){
		if(AppModel.instance.isOnline){
			if(AppModel.instance.userData.division==5){
				gameObject.transform.Find("Montee").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(60)+" Div.4";
				gameObject.transform.Find("Maintien").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(60);
			}
			else if(AppModel.instance.userData.division==1){
				gameObject.transform.Find("Montee").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(61)+" Div.3";
				gameObject.transform.Find("Maintien").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(61);
			}
			else{
				gameObject.transform.Find("Montee").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(61);
				gameObject.transform.Find("Maintien").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(60);
			}
			gameObject.transform.Find("Montee").FindChild("Title").GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.Find("Maintien").FindChild("Title").GetComponent<MeshRenderer>().enabled = true;

			if(AppModel.instance.userData.divisiongames==9){
				gameObject.transform.Find("MatchsRestants").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(63, new List<int>(){10-AppModel.instance.userData.divisiongames});
			}
			else{
				gameObject.transform.Find("MatchsRestants").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(64, new List<int>(){10-AppModel.instance.userData.divisiongames});
			}
			gameObject.transform.Find("MatchsRestants").GetComponent<MeshRenderer>().enabled = true;

			gameObject.transform.Find("OfflineText").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(65)+" "+AppModel.instance.userData.division;
				
			if(AppModel.instance.userData.division==1){
				gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().color = new Color(150f/255f, 150f/255f, 150f/255f);
				gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().color = new Color(150f/255f, 150f/255f, 150f/255f);
			}
			else if(AppModel.instance.userData.division==2){
				gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().color = new Color(110f/255f, 150f/255f, 165f/255f);
				gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().color = new Color(110f/255f, 150f/255f, 165f/255f);
			}
			else if(AppModel.instance.userData.division==3){
				gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f);
				gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f);
			}
			else if(AppModel.instance.userData.division==4){
				gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().color = new Color(151f/255f, 75f/255f, 128f/255f);
				gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().color = new Color(151f/255f, 75f/255f, 128f/255f);
			}
			else if(AppModel.instance.userData.division==5){
				gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().color = new Color(231f/255f, 0f/255f, 66f/255f);
				gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<TextMeshPro>().color = new Color(231f/255f, 0f/255f, 66f/255f);
			}
			gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().enabled = true;

			int nbToDisplay1 = 0;
			int nbToDisplay2 = 0;
			if(AppModel.instance.userData.division==1){
				nbToDisplay1 = 4 ;
				nbToDisplay2 = 3 ;
			}
			else if(AppModel.instance.userData.division==2){
				nbToDisplay1 = 3 ;
				nbToDisplay2 = 2 ;
			}
			else if(AppModel.instance.userData.division==3){
				nbToDisplay1 = 4 ;
				nbToDisplay2 = 2 ;
			}
			else if(AppModel.instance.userData.division==4){
				nbToDisplay1 = 4 ;
				nbToDisplay2 = 3 ;
			}
			else if(AppModel.instance.userData.division==5){
				nbToDisplay1 = 2 ;
				nbToDisplay2 = 3 ;
			}

			if(nbToDisplay1>=1){
				if(AppModel.instance.userData.divisionwins>=1){
					gameObject.transform.Find("Maintien").FindChild("Grad1").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Maintien").FindChild("Grad1").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Maintien").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Maintien").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay1>=2){
				if(AppModel.instance.userData.divisionwins>=2){
					gameObject.transform.Find("Maintien").FindChild("Grad2").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Maintien").FindChild("Grad2").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Maintien").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Maintien").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay1>=3){
				if(AppModel.instance.userData.divisionwins>=3){
					gameObject.transform.Find("Maintien").FindChild("Grad3").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Maintien").FindChild("Grad3").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Maintien").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Maintien").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay1>=4){
				if(AppModel.instance.userData.divisionwins>=4){
					gameObject.transform.Find("Maintien").FindChild("Grad4").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Maintien").FindChild("Grad4").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Maintien").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Maintien").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay2>=1){
				if(AppModel.instance.userData.divisionwins>=nbToDisplay1+1){
					gameObject.transform.Find("Montee").FindChild("Grad1").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Montee").FindChild("Grad1").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Montee").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Montee").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay2>=2){
				if(AppModel.instance.userData.divisionwins>=nbToDisplay1+2){
					gameObject.transform.Find("Montee").FindChild("Grad2").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Montee").FindChild("Grad2").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Montee").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Montee").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay2>=3){
				if(AppModel.instance.userData.divisionwins>=nbToDisplay1+3){
					gameObject.transform.Find("Montee").FindChild("Grad3").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Montee").FindChild("Grad3").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Montee").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Montee").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = false;
			}

			if(nbToDisplay2>=4){
				if(AppModel.instance.userData.divisionwins>=nbToDisplay1+4){
					gameObject.transform.Find("Montee").FindChild("Grad4").GetComponent<SpriteRenderer>().sprite = this.grads[1];
				}
				else{
					gameObject.transform.Find("Montee").FindChild("Grad4").GetComponent<SpriteRenderer>().sprite = this.grads[0];
				}
				gameObject.transform.Find("Montee").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				gameObject.transform.Find("Montee").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = false;
			}
			gameObject.transform.Find("Jouer").GetComponent<JouerButtonController>().show(true);
		}
		else{
			gameObject.transform.Find("Montee").FindChild("Title").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("Maintien").FindChild("Title").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("MatchsRestants").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("OfflineText").GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.Find("DivisionIcon").FindChild("TitleDivision").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("DivisionIcon").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Maintien").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Maintien").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Maintien").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Maintien").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Montee").FindChild("Grad1").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Montee").FindChild("Grad2").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Montee").FindChild("Grad3").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Montee").FindChild("Grad4").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Jouer").GetComponent<JouerButtonController>().show(false);
		}
	}
}