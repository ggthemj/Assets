using System;
using UnityEngine;
using TMPro;

public class TrainingCardController:MonoBehaviour
{
	public Sprite[] characters;
	int indexCarac;
	int idCard;

	void Awake()
	{
		this.indexCarac = 0;
		this.idCard = 0;
		this.show(false);
		this.initTexts();
	}

	public void initTexts(){
		gameObject.transform.FindChild("ButtonComeBack").GetComponent<ButtonComeBackController>().setText(AppModel.instance.getWording(8));
	}

	public void show(bool b){
		if(!b){
			gameObject.transform.FindChild("LoadingBackground").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("ChoiceValidation").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("Character").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("TexteChoix").GetComponent<MeshRenderer>().enabled = b;
			gameObject.transform.FindChild("TexteConseil").GetComponent<MeshRenderer>().enabled = b;
			gameObject.transform.FindChild("ButtonComeBack").GetComponent<ButtonComeBackController>().show(b);
			gameObject.transform.FindChild("LeftButton").GetComponent<LeftButtonController>().show(b);
			gameObject.transform.FindChild("RightButton").GetComponent<RightButtonController>().show(b);
			gameObject.transform.FindChild("ChosenCarac").GetComponent<MeshRenderer>().enabled = b;
			gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().show(b);
			gameObject.transform.FindChild("Texte0").GetComponent<MeshRenderer>().enabled = b;
		}
		else{
			if(this.indexCarac<2){
				gameObject.transform.FindChild("Texte0").GetComponent<MeshRenderer>().enabled = b;
				gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().show(!b);
			}
			else{
				gameObject.transform.FindChild("Texte0").GetComponent<MeshRenderer>().enabled = !b;
				gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().show(b);
			}
			gameObject.transform.FindChild("LoadingBackground").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("ChoiceValidation").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("Character").GetComponent<SpriteRenderer>().enabled = b;
			gameObject.transform.FindChild("TexteChoix").GetComponent<MeshRenderer>().enabled = b;
			gameObject.transform.FindChild("TexteConseil").GetComponent<MeshRenderer>().enabled = b;
			gameObject.transform.FindChild("ButtonComeBack").GetComponent<ButtonComeBackController>().show(b);
			gameObject.transform.FindChild("LeftButton").GetComponent<LeftButtonController>().show(b);
			gameObject.transform.FindChild("RightButton").GetComponent<RightButtonController>().show(b);
			gameObject.transform.FindChild("ChosenCarac").GetComponent<MeshRenderer>().enabled = b;
		}
	}

	public void updateInfos(){
		gameObject.transform.FindChild("Character").GetComponent<SpriteRenderer>().sprite = this.characters[this.idCard];
		gameObject.transform.FindChild("TexteChoix").GetComponent<TextMeshPro>().text = AppModel.instance.getCardNameText(this.idCard)+", "+AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].getLevel();
		gameObject.transform.FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(7);
		if(this.indexCarac==0){
			gameObject.transform.FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(9);
			if(AppModel.instance.getMoveCard(this.idCard,AppModel.instance.userData.cards[this.idCard].move)>1){
				gameObject.transform.FindChild("Texte0").GetComponent<TextMeshPro>().text = AppModel.instance.getMoveCard(this.idCard,AppModel.instance.userData.cards[this.idCard].move).ToString()+" "+AppModel.instance.getWording(13);
			}
			else{
				gameObject.transform.FindChild("Texte0").GetComponent<TextMeshPro>().text = "1 "+AppModel.instance.getWording(14);
			}
		}
		else if(this.indexCarac==1){
			gameObject.transform.FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(10);
			gameObject.transform.FindChild("Texte0").GetComponent<TextMeshPro>().text = AppModel.instance.getLifeCard(this.idCard,AppModel.instance.userData.cards[this.idCard].life).ToString()+" "+AppModel.instance.getWording(15);
		}
		else if(this.indexCarac==2){
			gameObject.transform.FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(12);
			gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0, AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0));
		}
		else if(this.indexCarac>2){
			gameObject.transform.FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(11)+" N°"+(this.indexCarac-2);
			if(this.indexCarac==3){
				gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0,AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill1));
			}
			else if(this.indexCarac==4){
				gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0,AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill2));
			}
			else{
				gameObject.transform.FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0,AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill3));
			}

		}
	}
}