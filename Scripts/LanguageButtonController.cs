using System;
using UnityEngine;

public class LanguageButtonController : ButtonController
{
	public LanguageButtonController ()
	{

	}

	public override void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	public override void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	public override void OnMouseDown(){
		AppModel.instance.changeLanguage();
		this.setSprite();
	}

	public void setSprite(){
		if (AppModel.instance.languageID==0){
			gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = base.hoveredSprite;
		}
	}
}