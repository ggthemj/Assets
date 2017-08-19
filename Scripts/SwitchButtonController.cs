using System;
using UnityEngine;

public class SwitchButtonController : ButtonController
{
	public int id;
	public bool disabled;

	void Start(){
		this.setSprite();
		this.disabled = false;
	}

	public override void OnMouseOver(){
		if (this.disabled) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (231f / 255f, 0f / 255f, 66f / 255f, 1f);
		} 
		else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (71f / 255f, 150f / 255f, 189f / 255f, 1f);
		}
	}

	public override void OnMouseExit(){
		if (this.disabled) {
			gameObject.GetComponent<SpriteRenderer>().color = new Color(150f/255f, 150f/255f, 150f/255f, 1f);
		} 
		else {
			gameObject.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
	}

	public override void OnMouseDown(){
		if (this.disabled) {
			AppModel.instance.noPM ();
		} 
		else {
			PregameManager.instance.hitSwitch (this.id);
		}
	}

	public void disable(){
		this.disabled = true;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(150f/255f, 150f/255f, 150f/255f, 1f);
	}

	public void setSprite(){
		gameObject.GetComponent<SpriteRenderer>().sprite = base.normalSprite;
	}
}