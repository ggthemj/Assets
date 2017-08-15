using System;
using UnityEngine;

public class BuySkillButtonController : ButtonController
{
	public int id;
	public bool red;

	void Start(){
		this.setSprite();
	}

	public override void OnMouseOver(){
		if(!red){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		}
	}

	public override void OnMouseExit(){
		if(!red){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
	}

	public void setRed(bool r){
		if(r){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(231f/255f, 0f/255f, 66f/255f, 1f);
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
		this.red = r;
	}

	public override void OnMouseDown(){
		if(!red){
			AppModel.instance.buySkill(this.id);
		}
		else{
			AppModel.instance.hitNotEnoughMoney();
		}
	}

	public void setSprite(){
		gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
	}
}