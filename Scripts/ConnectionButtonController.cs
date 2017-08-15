using System;
using UnityEngine;

public class ConnectionButtonController : ButtonController
{
	void Start(){
		this.updateSprite();
	}

	public override void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	public override void OnMouseExit(){
		if (AppModel.instance.isOnline){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(231f/255f, 0f/255f, 66f/255f, 1f);
		}
	}

	public override void OnMouseDown(){
		AppModel.instance.testConnection();
	}

	public void updateSprite(){
		if (AppModel.instance.isOnline){
			gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
			gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = base.hoveredSprite;
			gameObject.GetComponent<SpriteRenderer>().color = new Color(231f/255f, 0f/255f, 66f/255f, 1f);
		}
	}

}