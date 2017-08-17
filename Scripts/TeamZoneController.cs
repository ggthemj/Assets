using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TeamZoneController:MonoBehaviour
{
	public List<bool> toChangeCard;
	public List<bool> backDisplayed;

	void Start(){
		this.toChangeCard = new List<bool>();
		toChangeCard.Add(false);
		toChangeCard.Add(false);
		toChangeCard.Add(false);
		toChangeCard.Add(false);
		this.backDisplayed = new List<bool>();
		backDisplayed.Add(false);
		backDisplayed.Add(false);
		backDisplayed.Add(false);
		backDisplayed.Add(false);
		this.showBack(0);
		this.showBack(1);
		this.showBack(2);
		this.showBack(3);
	}

	public void showBack(int i){
		gameObject.transform.Find("Card"+i).FindChild("Back").GetComponent<SpriteRenderer>().enabled = this.backDisplayed[i];
	}

	public void initTexts(){
		gameObject.transform.Find("TitleZone").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(74);
		gameObject.transform.Find("Comment").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(75);
	}

	public void displayTimer(string s){
		gameObject.transform.Find("PointsManoeuvre").GetComponent<TextMeshPro>().text = s;
	}

	public void showMalusTimer(bool b){
		gameObject.transform.Find("Malus").GetComponent<MeshRenderer>().enabled = b;
		if(!b){
			gameObject.transform.Find("Malus").transform.localPosition = new Vector3(0.5f, 4.2f, 0f);
		}
	}

	public void setMalusTimerPosition(float pourcentage){
		gameObject.transform.Find("Malus").transform.localPosition = new Vector3(Mathf.Min(2.5f, 0.5f+2*pourcentage), 4.2f, 0f);
		gameObject.transform.Find("Malus").GetComponent<TextMeshPro>().color = new Color(231f/255f, 0f, 66f/255f, pourcentage*255f);
	}

	public void setCardPosition(int id, float pourcentage){
		if(!this.backDisplayed[id]){
			if(pourcentage>=0.25f && pourcentage<0.75f){
				this.backDisplayed[id]=true;
				this.showBack(id);
				this.toChangeCard[id]=false;
				this.updateCard(id);
			}
		}
		else{
			if(pourcentage>=0.75f){
				this.backDisplayed[id]=false;
				this.showBack(id);
			}
		}
		gameObject.transform.Find("Card"+id).transform.localRotation = Quaternion.Euler(0f, Mathf.Min(360f, 360f*pourcentage), 0f);
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
		for(int i = 0 ; i < 4 ; i++){
			gameObject.transform.Find("Card"+i).GetComponent<BoxCollider2D>().enabled = b;
		}
	}

	public void showMobileColliders(bool b){

	}

	public void showDesktop(bool b){
		
	}

	public void updateCard(int i){
		int temp = PregameManager.instance.getUnite(i);
		if(AppModel.instance.userData.cards[temp].getLevel()>=20){
			gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCardBackground(4);
		}
		else if(AppModel.instance.userData.cards[temp].getLevel()>=15){
			gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCardBackground(3);
		}
		else if(AppModel.instance.userData.cards[temp].getLevel()>=10){
			gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCardBackground(2);
		}
		else if(AppModel.instance.userData.cards[temp].getLevel()>=5){
			gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCardBackground(1);
		}
		else{
			gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCardBackground(0);
		}
		gameObject.transform.Find("Card"+i).FindChild("CaracBackground").GetComponent<SpriteRenderer>().enabled = true;
		gameObject.transform.Find("Card"+i).FindChild("Unit").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getCharacter(temp);

		if(AppModel.instance.userData.cards[temp].skill1>0){
			gameObject.transform.Find("Card"+i).FindChild("LifeValue").GetComponent<TextMeshPro>().text = AppModel.instance.getLifeCard(temp,AppModel.instance.userData.cards[temp].life).ToString();
			gameObject.transform.Find("Card"+i).FindChild("LifeValue").GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("SpeedValue").GetComponent<TextMeshPro>().text = AppModel.instance.getMoveCard(temp,AppModel.instance.userData.cards[temp].move).ToString();
			gameObject.transform.Find("Card"+i).FindChild("SpeedValue").GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("SpeedIcon").GetComponent<SpriteRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("LifeIcon").GetComponent<SpriteRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("Icon1").GetComponent<SpriteRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("Icon1").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*temp+1);
			if(AppModel.instance.userData.cards[temp].skill0>0){
				gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*temp);
			}
			else{
				gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().enabled = false;
			}
			if(AppModel.instance.userData.cards[temp].skill2>0){
				gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*temp+2);
			}
			else{
				gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().enabled = false;
			}
			if(AppModel.instance.userData.cards[temp].skill3>0){
				gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*temp+3);
			}
			else{
				gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().enabled = false;
			}
			gameObject.transform.Find("Card"+i).FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(5, new List<int>(){AppModel.instance.userData.cards[temp].getLevel()});
			gameObject.transform.Find("Card"+i).FindChild("Name").GetComponent<MeshRenderer>().enabled = false;
		}
		else{
			gameObject.transform.Find("Card"+i).FindChild("LifeValue").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("SpeedValue").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("SpeedIcon").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("LifeIcon").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Icon1").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Niveau").GetComponent<MeshRenderer>().enabled = false;
			gameObject.transform.Find("Card"+i).FindChild("Name").GetComponent<TextMeshPro>().text = AppModel.instance.getCardNameText(temp);
			gameObject.transform.Find("Card"+i).FindChild("Name").GetComponent<MeshRenderer>().enabled = true;
		}
	}

	public void updateCards(){
		for(int i = 0 ; i < 4 ; i++){
			this.updateCard(i);
		}
	}

	public void resize(){
		float w = AppModel.instance.widthScreen;
		float h = AppModel.instance.heightScreen;
		if(AppModel.instance.widthScreen>AppModel.instance.heightScreen){
			gameObject.transform.localPosition = new Vector3(0f,0f,0f);
			gameObject.transform.Find("Background").localScale = new Vector3(3000f,1080f,0f);
			gameObject.transform.Find("TitleZone").GetComponent<RectTransform>().sizeDelta = new Vector2((0.9f*10f*w)/h,0.5f);
			gameObject.transform.Find("PointsManoeuvre").GetComponent<RectTransform>().sizeDelta = new Vector2((0.5f*10f*w)/h,0.5f);
			gameObject.transform.Find("Comment").GetComponent<RectTransform>().sizeDelta = new Vector2((0.8f*10f*w)/h,1.5f);

			gameObject.transform.Find("Card0").localPosition = new Vector3(-1*((0.36f)*10f*w)/h,1.5f,0f);
			gameObject.transform.Find("Card1").localPosition = new Vector3(-1*((0.12f)*10f*w)/h,1.5f,0f);
			gameObject.transform.Find("Card2").localPosition = new Vector3(1*((0.12f)*10f*w)/h,1.5f,0f);
			gameObject.transform.Find("Card3").localPosition = new Vector3(1*((0.36f)*10f*w)/h,1.5f,0f);
			gameObject.transform.Find("Change0").localPosition = new Vector3(-1*((0.36f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Change1").localPosition = new Vector3(-1*((0.08f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Change2").localPosition = new Vector3(1*((0.16f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Change3").localPosition = new Vector3(1*((0.40f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Forward1").localPosition = new Vector3(-1*((0.16f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Forward2").localPosition = new Vector3(1*((0.08f)*10f*w)/h,-1f,0f);
			gameObject.transform.Find("Forward3").localPosition = new Vector3(1*((0.32f)*10f*w)/h,-1f,0f);
		}
	}

	public void showSwitch(int i, bool b){
		gameObject.transform.Find("Change"+i).GetComponent<SwitchButtonController>().show(b);
	}

	public void showForward(int i, bool b){
		gameObject.transform.Find("Forward"+i).GetComponent<SwitchButtonController>().show(b);
	}
}