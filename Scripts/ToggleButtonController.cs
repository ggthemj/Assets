﻿using System;
using UnityEngine;

public class ToggleButtonController:ButtonController
{
	public ToggleButtonController ()
	{

	}

	public override void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	public override void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	public override void OnMouseDown(){
		AuthentManager.instance.hitToggle();	
	}

	public void setSprite(int toggle){
		if(toggle==0){
			gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = base.hoveredSprite;
		}
	}
}