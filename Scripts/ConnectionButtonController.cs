using System;
using UnityEngine;

public class ConnectionButtonController : ButtonController
{
	void Start(){
		this.setSprite();
	}

	public override void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	public override void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	public override void OnMouseDown(){
		if(!AppModel.instance.isOnline){
			AppModel.instance.testConnection();
		}
	}

	public void setSprite(){
		if (AppModel.instance.isOnline){
			gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = base.hoveredSprite;
		}
	}
}