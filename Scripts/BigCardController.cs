using System;
using UnityEngine;
using TMPro;

public class BigCardController:MonoBehaviour
{
	public int idCard;
	bool toShowLogo1, toShowLogo2, toShowLogo3, toShowLogo4;
	public Sprite[] bigCardSprites;

	void Awake(){
		this.show(false);
		this.showColliders(false);
	}

	public void initTexts(){
		gameObject.transform.Find("Card").FindChild("ButtonComeBack").GetComponent<ButtonComeBackController>().setText(AppModel.instance.getWording(28));
	}

	public void showColliders(bool b){
		gameObject.transform.Find("Card").FindChild("Life").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Speed").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill0").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill1").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill2").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill3").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill3").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("LeftButton").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("RightButton").GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.Find("Card").FindChild("ButtonComeBack").GetComponent<BoxCollider2D>().enabled = b;
	}

	public void show(bool b){
		gameObject.transform.Find("Background").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("CaracBackground").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Life").FindChild("Value").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Speed").FindChild("Value").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Life").FindChild("Icon").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Speed").FindChild("Icon").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Unit").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.Find("Card").FindChild("Skill0").GetComponent<BigCardSkillController>().show(b,toShowLogo1);
		gameObject.transform.Find("Card").FindChild("Skill1").GetComponent<BigCardSkillController>().show(b,toShowLogo2);
		gameObject.transform.Find("Card").FindChild("Skill2").GetComponent<BigCardSkillController>().show(b,toShowLogo3);
		gameObject.transform.Find("Card").FindChild("Skill3").GetComponent<BigCardSkillController>().show(b,toShowLogo4);
		gameObject.transform.Find("Card").FindChild("Niveau").GetComponent<MeshRenderer>().enabled=b;
		gameObject.transform.Find("Card").FindChild("Name").GetComponent<MeshRenderer>().enabled=b;
		gameObject.transform.Find("Card").FindChild("ButtonComeBack").GetComponent<ButtonComeBackController>().show(b);
		gameObject.transform.Find("Card").FindChild("LeftButton").GetComponent<LeftBigCardButtonController>().show(b);
		gameObject.transform.Find("Card").FindChild("RightButton").GetComponent<RightBigCardButtonController>().show(b);
	}

	public void updateValues(){
		gameObject.transform.Find("Card").GetComponent<SpriteRenderer>().sprite = this.bigCardSprites[(int)Mathf.Min(5,Mathf.FloorToInt(AppModel.instance.userData.cards[this.idCard].getLevel()/5f))];
		gameObject.transform.Find("Card").FindChild("Life").FindChild("Value").GetComponent<TextMeshPro>().text = AppModel.instance.getLifeCard(this.idCard,AppModel.instance.userData.cards[this.idCard].life).ToString();
		gameObject.transform.Find("Card").FindChild("Speed").FindChild("Value").GetComponent<TextMeshPro>().text = AppModel.instance.getMoveCard(this.idCard,AppModel.instance.userData.cards[this.idCard].move).ToString();
		gameObject.transform.Find("Card").FindChild("Unit").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getBigCharacterSprite(this.idCard);
		gameObject.transform.Find("Card").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].getLevel();
		gameObject.transform.Find("Card").FindChild("Name").GetComponent<TextMeshPro>().text = AppModel.instance.getCardNameText(this.idCard);
		if(AppModel.instance.userData.cards[this.idCard].skill0>=1){
			this.toShowLogo1 = true;
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillNameText(4*this.idCard);
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillDescription(4*this.idCard, AppModel.instance.userData.cards[this.idCard].skill0);
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].skill0+"/5";
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Logo").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*this.idCard);
		}
		else{
			this.toShowLogo1 = false;
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Title").GetComponent<TextMeshPro>().text = "???";
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(24);
			gameObject.transform.Find("Card").FindChild("Skill0").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(25);
		}
		if(AppModel.instance.userData.cards[this.idCard].skill1>=1){
			this.toShowLogo2 = true;
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillNameText(4*this.idCard+1);
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillDescription(4*this.idCard+1, AppModel.instance.userData.cards[this.idCard].skill1);
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].skill1+"/5";
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Logo").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*this.idCard+1);
		}
		else{
			this.toShowLogo2 = false;
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Title").GetComponent<TextMeshPro>().text = "???";
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(23);
			gameObject.transform.Find("Card").FindChild("Skill1").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(25);
		}
		if(AppModel.instance.userData.cards[this.idCard].skill2>=1){
			this.toShowLogo3 = true;
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillNameText(4*this.idCard+2);
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillDescription(4*this.idCard+2, AppModel.instance.userData.cards[this.idCard].skill2);
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].skill2+"/5";
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Logo").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*this.idCard+2);
		}
		else{
			this.toShowLogo3 = false;
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Title").GetComponent<TextMeshPro>().text = "???";
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(23);
			gameObject.transform.Find("Card").FindChild("Skill2").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(25);
		}
		if(AppModel.instance.userData.cards[this.idCard].skill3>=1){
			this.toShowLogo4 = true;
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Title").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillNameText(4*this.idCard+3);
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getSkillDescription(4*this.idCard+3, AppModel.instance.userData.cards[this.idCard].skill3);
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+AppModel.instance.userData.cards[this.idCard].skill3+"/5";
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Logo").GetComponent<SpriteRenderer>().sprite = AppModel.instance.getSkillSprite(4*this.idCard+3);
		}
		else{
			this.toShowLogo4 = false;
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Title").GetComponent<TextMeshPro>().text = "???";
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Description").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(23);
			gameObject.transform.Find("Card").FindChild("Skill3").FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(25);
		}
	}
}