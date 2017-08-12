using System;
using UnityEngine;
using TMPro;

public class TrainingCardController:MonoBehaviour
{
	public Sprite[] characters;
	public int indexCarac;
	public int idCard;
	bool toShowText0;
	bool toShowText0Bis;
	bool toShowSkill0;
	bool toShow1;
	bool toShow2;
	bool toShow3;
	bool toShow4;
	bool toShowBuyButton0;

	void Awake()
	{
		this.indexCarac = 0;
		this.idCard = 0;
		this.show(false);
	}

	public void initTexts(){
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackBC").GetComponent<ButtonComeBackBCController>().setText(AppModel.instance.getWording(28));
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackHome").GetComponent<ButtonComeBackHomeController>().setText(AppModel.instance.getWording(29));
	}

	public void showColliders(bool b){
		gameObject.transform.Find("ChoiceValidation").FindChild("LeftButton").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("RightButton").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackBC").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackHome").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton3").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton4").GetComponent<BoxCollider2D>().enabled=b;
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton0").GetComponent<BoxCollider2D>().enabled=b;
	}

	public void show(bool b){
		gameObject.transform.FindChild("LoadingBackground").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("ChoiceValidation").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("ChoiceValidation").FindChild("Character").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("ChoiceValidation").FindChild("TexteChoix").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("ChoiceValidation").FindChild("TexteConseil").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackBC").GetComponent<ButtonComeBackBCController>().show(b);
		gameObject.transform.Find("ChoiceValidation").FindChild("ButtonComeBackHome").GetComponent<ButtonComeBackHomeController>().show(b);
		gameObject.transform.Find("ChoiceValidation").FindChild("LeftButton").GetComponent<LeftButtonController>().show(b);
		gameObject.transform.Find("ChoiceValidation").FindChild("RightButton").GetComponent<RightButtonController>().show(b);
		gameObject.transform.Find("ChoiceValidation").FindChild("ChosenCarac").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("ChoiceValidation").FindChild("Skill0").GetComponent<SkillCardController>().show(b & toShowSkill0);
		gameObject.transform.Find("ChoiceValidation").FindChild("Texte0").GetComponent<MeshRenderer>().enabled = (b & toShowText0);
		gameObject.transform.Find("ChoiceValidation").FindChild("Texte0Bis").GetComponent<MeshRenderer>().enabled = (b & toShowText0Bis);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<MeshRenderer>().enabled = (b & toShow1);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyText2").GetComponent<MeshRenderer>().enabled = (b & toShow2);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyText3").GetComponent<MeshRenderer>().enabled = (b & toShow3);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyText4").GetComponent<MeshRenderer>().enabled = (b & toShow4);
		gameObject.transform.Find("ChoiceValidation").FindChild("IconUpgrade1").GetComponent<SpriteRenderer>().enabled = (b & toShow1);
		gameObject.transform.Find("ChoiceValidation").FindChild("IconUpgrade2").GetComponent<SpriteRenderer>().enabled = (b & toShow2);
		gameObject.transform.Find("ChoiceValidation").FindChild("IconUpgrade3").GetComponent<SpriteRenderer>().enabled = (b & toShow3);
		gameObject.transform.Find("ChoiceValidation").FindChild("IconUpgrade4").GetComponent<SpriteRenderer>().enabled = (b & toShow4);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<MeshRenderer>().enabled = (b & toShow1);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel2").GetComponent<MeshRenderer>().enabled = (b & toShow2);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel3").GetComponent<MeshRenderer>().enabled = (b & toShow3);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel4").GetComponent<MeshRenderer>().enabled = (b & toShow4);
		gameObject.transform.Find("ChoiceValidation").FindChild("Cristal1").GetComponent<SpriteRenderer>().enabled = (b & toShow1);
		gameObject.transform.Find("ChoiceValidation").FindChild("Cristal2").GetComponent<SpriteRenderer>().enabled = (b & toShow2);
		gameObject.transform.Find("ChoiceValidation").FindChild("Cristal3").GetComponent<SpriteRenderer>().enabled = (b & toShow3);
		gameObject.transform.Find("ChoiceValidation").FindChild("Cristal4").GetComponent<SpriteRenderer>().enabled = (b & toShow4);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().show(b & toShow1);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BuySkillButtonController>().show(b & toShow2);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton3").GetComponent<BuySkillButtonController>().show(b & toShow3);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton4").GetComponent<BuySkillButtonController>().show(b & toShow4);
		gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton0").GetComponent<BuySkillButtonController>().show(b & toShowBuyButton0);
		gameObject.transform.Find("ChoiceValidation").FindChild("Cristal0").GetComponent<SpriteRenderer>().enabled = (b & toShowBuyButton0);
	}

	public void updateInfos(){
		this.toShowText0 = false;
		this.toShowSkill0 = true;
		gameObject.transform.Find("ChoiceValidation").FindChild("Character").GetComponent<SpriteRenderer>().sprite = this.characters[this.idCard];
		gameObject.transform.Find("ChoiceValidation").FindChild("TexteChoix").GetComponent<TextMeshPro>().text = AppModel.instance.getCardNameText(this.idCard)+", "+AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].getLevel();
		gameObject.transform.Find("ChoiceValidation").FindChild("TexteConseil").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(7);
		if(this.indexCarac==0){
			this.toShowSkill0 = false;
			this.toShowText0 = true;
			gameObject.transform.Find("ChoiceValidation").FindChild("ChosenCarac").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(10);
			if(AppModel.instance.getMoveCard(this.idCard,AppModel.instance.userData.cards[this.idCard].move)>1){
				gameObject.transform.Find("ChoiceValidation").FindChild("Texte0").GetComponent<TextMeshPro>().text = AppModel.instance.getMoveCard(this.idCard,AppModel.instance.userData.cards[this.idCard].move).ToString()+" "+AppModel.instance.getWording(13);
			}
			else{
				gameObject.transform.Find("ChoiceValidation").FindChild("Texte0").GetComponent<TextMeshPro>().text = "1 "+AppModel.instance.getWording(14);
			}
		}
		else if(this.indexCarac==1){
			this.toShowSkill0 = false;
			this.toShowText0 = true;
			gameObject.transform.Find("ChoiceValidation").FindChild("ChosenCarac").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(9);
			gameObject.transform.Find("ChoiceValidation").FindChild("Texte0").GetComponent<TextMeshPro>().text = AppModel.instance.getLifeCard(this.idCard,AppModel.instance.userData.cards[this.idCard].life).ToString()+" "+AppModel.instance.getWording(15);
		}
		else if(this.indexCarac==2){
			gameObject.transform.Find("ChoiceValidation").FindChild("ChosenCarac").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(12);
			gameObject.transform.Find("ChoiceValidation").FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac), AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].skill0));
		}
		else if(this.indexCarac>2){
			gameObject.transform.Find("ChoiceValidation").FindChild("ChosenCarac").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(11)+" N°"+(this.indexCarac-2);
			gameObject.transform.Find("ChoiceValidation").FindChild("Skill0").GetComponent<SkillCardController>().updateInfos(AppModel.instance.getSkillNameText(4*idCard+(this.indexCarac-2)),AppModel.instance.getSkillSprite(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac),AppModel.instance.getSkillDescription(4*this.idCard+(this.indexCarac-2), AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)));
		}

		this.toShow4 = false;
		this.toShow3 = false;
		this.toShow2 = false;
		this.toShow1 = false;
		this.toShowBuyButton0 = false;
		if(this.indexCarac>0){
			if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==5){
				this.toShowText0Bis = true;
				if(this.indexCarac==1){
					gameObject.transform.Find("ChoiceValidation").FindChild("Texte0Bis").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(20);
				}
				else{
					gameObject.transform.Find("ChoiceValidation").FindChild("Texte0Bis").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(21);
				}
			}
			else if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==4){
				this.toShow1 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 5";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 5, 4));
			}
			else if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==3){
				this.toShow1 = true;
				this.toShow2 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 4";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 4, 3));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText2").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 2);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel2").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 5";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 5, 3));
			}
			else if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==2){
				this.toShow1 = true;
				this.toShow2 = true;
				this.toShow3 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 3";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 3, 2));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText2").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 2);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel2").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 4";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 4, 2));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText3").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 3);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel3").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 5";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton3").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 5, 2));
			}
			else if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==1){
				this.toShow1 = true;
				this.toShow2 = true;
				this.toShow3 = true;
				this.toShow4 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 2";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 2, 1));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText2").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 2);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel2").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 3";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 3, 1));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText3").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 3);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel3").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 4";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton3").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 4, 1));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText4").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 4);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel4").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 5";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton4").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 5, 1));
			}
			else if(AppModel.instance.userData.cards[this.idCard].getCarac(this.indexCarac)==0){
				this.toShowBuyButton0 = true;
				this.toShowText0 = true;
				gameObject.transform.Find("ChoiceValidation").FindChild("Texte0").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 1, 0);
			}
		}
		else{
			if(AppModel.instance.userData.cards[this.idCard].move==3){
				this.toShowText0Bis = true;
				gameObject.transform.Find("ChoiceValidation").FindChild("Texte0Bis").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(18);
			}
			else if(AppModel.instance.userData.cards[this.idCard].move==2){
				this.toShow1 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 3";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 3, 2));
			}
			else if(AppModel.instance.userData.cards[this.idCard].move==1){
				this.toShow1 = true;
				this.toShow2 = true;
				this.toShowText0Bis = false;
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText1").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 1);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyText2").GetComponent<TextMeshPro>().text = AppModel.instance.getBonus(this.idCard, this.indexCarac, 2);
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel1").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 2";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyLevel2").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" 3";
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton1").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 2, 1));
				gameObject.transform.Find("ChoiceValidation").FindChild("BuyButton2").GetComponent<BuySkillButtonController>().setText(AppModel.instance.getWording(22)+"\n"+AppModel.instance.getPrice(this.indexCarac, 3, 1));
			}
		}
	}
}