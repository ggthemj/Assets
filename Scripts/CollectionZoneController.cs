using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CollectionZoneController:MonoBehaviour
{
	public Sprite[] backgroundCards;
	public Sprite[] characters;

	void Start(){
		this.resize();
		this.updateCards(0);
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
		for(int i = 0 ; i < 12 ; i++){
			gameObject.transform.Find("Card"+i).GetComponent<BoxCollider2D>().enabled = b;
		}
	}

	public void showMobileColliders(bool b){

	}

	public void showDesktop(bool b){
		
	}

	public void updateCards(int page){
		for(int i = 0 ; i < 12 ; i++){
			if(AppModel.instance.userData.cards[page*12+i].getLevel()>=20){
				gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = this.backgroundCards[4];
			}
			else if(AppModel.instance.userData.cards[page*12+i].getLevel()>=15){
				gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = this.backgroundCards[3];
			}
			else if(AppModel.instance.userData.cards[page*12+i].getLevel()>=10){
				gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = this.backgroundCards[2];
			}
			else if(AppModel.instance.userData.cards[page*12+i].getLevel()>=5){
				gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = this.backgroundCards[1];
			}
			else{
				gameObject.transform.Find("Card"+i).GetComponent<SpriteRenderer>().sprite = this.backgroundCards[0];
			}
			gameObject.transform.Find("Card"+i).FindChild("CaracBackground").GetComponent<SpriteRenderer>().enabled = true;
			gameObject.transform.Find("Card"+i).FindChild("Unit").GetComponent<SpriteRenderer>().sprite = this.characters[page*12+i];

			if(AppModel.instance.userData.cards[0].skill1>0){
				Debug.Log(AppModel.instance.userData.cards[page*12+i].life);
				gameObject.transform.Find("Card"+i).FindChild("LifeValue").GetComponent<TextMeshPro>().text = AppModel.instance.getLifeCard(page*12+i,AppModel.instance.userData.cards[page*12+i].life).ToString();
				gameObject.transform.Find("Card"+i).FindChild("LifeValue").GetComponent<MeshRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("SpeedValue").GetComponent<TextMeshPro>().text = AppModel.instance.getMoveCard(page*12+i,AppModel.instance.userData.cards[page*12+i].move).ToString();
				gameObject.transform.Find("Card"+i).FindChild("SpeedValue").GetComponent<MeshRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("SpeedIcon").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("LifeIcon").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Icon1").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Icon1").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(page*12+4*i+1);
				if(AppModel.instance.userData.cards[page*12+i].skill0>0){
					gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().enabled = true;
					gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(page*12+4*i);
				}
				else{
					gameObject.transform.Find("Card"+i).FindChild("Icon0").GetComponent<SpriteRenderer>().enabled = false;
				}
				if(AppModel.instance.userData.cards[page*12+i].skill2>0){
					gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().enabled = true;
					gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(page*12+4*i+2);
				}
				else{
					gameObject.transform.Find("Card"+i).FindChild("Icon2").GetComponent<SpriteRenderer>().enabled = false;
				}
				if(AppModel.instance.userData.cards[page*12+i].skill3>0){
					gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().enabled = true;
					gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(page*12+4*i+3);
				}
				else{
					gameObject.transform.Find("Card"+i).FindChild("Icon3").GetComponent<SpriteRenderer>().enabled = false;
				}
				gameObject.transform.Find("Card"+i).FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(5, new List<int>(){AppModel.instance.userData.cards[page*12+i].getLevel()});
				gameObject.transform.Find("Card"+i).FindChild("GreyBack").GetComponent<SpriteRenderer>().enabled = false;
				gameObject.transform.Find("Card"+i).FindChild("LockedZone").GetComponent<SpriteRenderer>().enabled = false;
				gameObject.transform.Find("Card"+i).FindChild("LockedZone").FindChild("LockedText").GetComponent<MeshRenderer>().enabled = false;
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
				gameObject.transform.Find("Card"+i).FindChild("GreyBack").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("LockedZone").GetComponent<SpriteRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("LockedZone").FindChild("LockedText").GetComponent<TextMeshPro>().text = AppModel.instance.getUnlockText(page*12+i);
				gameObject.transform.Find("Card"+i).FindChild("LockedZone").FindChild("LockedText").GetComponent<MeshRenderer>().enabled = true;
				gameObject.transform.Find("Card"+i).FindChild("Name").GetComponent<TextMeshPro>().text = AppModel.instance.getCardNameText(page*12+i);;
				gameObject.transform.Find("Card"+i).FindChild("Name").GetComponent<MeshRenderer>().enabled = true;
			}
		}
	}

	public void resize(){
		float w = AppModel.instance.widthScreen;
		float h = AppModel.instance.heightScreen;
		if(AppModel.instance.widthScreen>AppModel.instance.heightScreen){
			gameObject.transform.Find("Background").localPosition = new Vector3((-1*((10f*w/h)/6f)),-0.60f,0f);
			gameObject.transform.Find("Background").localScale = new Vector3((1*(1080f*0.64f*w/h)),910f,0f);
			gameObject.transform.Find("TitleZone").localPosition = new Vector3((-1*((10f*w/h)/2f-3f)),3.25f,0f);
			gameObject.transform.Find("Comment").localPosition = new Vector3((-1*((10f*w/h)/6f)),-4.55f,0f);
			gameObject.transform.Find("Comment").GetComponent<RectTransform>().sizeDelta = new Vector2((20f*w/h)/3.2f,0.5f);
			gameObject.transform.Find("Card0").localPosition = new Vector3((-1*((10f*w/h)/6f+(3*6.4f*w/h)/8f)),1.75f,0f);
			gameObject.transform.Find("Card1").localPosition = new Vector3((-1*((10f*w/h)/6f+(6.4f*w/h)/8f)),1.75f,0f);
			gameObject.transform.Find("Card2").localPosition = new Vector3((-1*((10f*w/h)/6f-(6.4f*w/h)/8f)),1.75f,0f);
			gameObject.transform.Find("Card3").localPosition = new Vector3((-1*((10f*w/h)/6f-(3*6.4f*w/h)/8f)),1.75f,0f);
			gameObject.transform.Find("Card4").localPosition = new Vector3((-1*((10f*w/h)/6f+(3*6.4f*w/h)/8f)),-0.75f,0f);
			gameObject.transform.Find("Card5").localPosition = new Vector3((-1*((10f*w/h)/6f+(6.4f*w/h)/8f)),-0.75f,0f);
			gameObject.transform.Find("Card6").localPosition = new Vector3((-1*((10f*w/h)/6f-(6.4f*w/h)/8f)),-0.75f,0f);
			gameObject.transform.Find("Card7").localPosition = new Vector3((-1*((10f*w/h)/6f-(3*6.4f*w/h)/8f)),-0.75f,0f);
			gameObject.transform.Find("Card8").localPosition = new Vector3((-1*((10f*w/h)/6f+(3*6.4f*w/h)/8f)),-3.25f,0f);
			gameObject.transform.Find("Card9").localPosition = new Vector3((-1*((10f*w/h)/6f+(6.4f*w/h)/8f)),-3.25f,0f);
			gameObject.transform.Find("Card10").localPosition = new Vector3((-1*((10f*w/h)/6f-(6.4f*w/h)/8f)),-3.25f,0f);
			gameObject.transform.Find("Card11").localPosition = new Vector3((-1*((10f*w/h)/6f-(3*6.4f*w/h)/8f)),-3.25f,0f);
		}
	}
}