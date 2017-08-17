using System;
using UnityEngine;

public class SwitchButtonController : ButtonController
{
	public int id;

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
		PregameManager.instance.hitSwitch(this.id);
	}

	public void setSprite(){
		gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
	}
}