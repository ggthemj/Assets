using System;
using UnityEngine;

public class HomeQuitButtonController : ButtonController
{
	public HomeQuitButtonController ()
	{

	}

	public override void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	public override void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	public override void OnMouseDown(){
		HomeManager.instance.quitGame();
	}
}