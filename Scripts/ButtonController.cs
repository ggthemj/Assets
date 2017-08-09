using System;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
	public Sprite normalSprite;
	public Sprite hoveredSprite;

	void Awake(){
		gameObject.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
	}

	public virtual void OnMouseOver(){
		gameObject.GetComponent<SpriteRenderer>().sprite = this.hoveredSprite;
	}

	public virtual void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer>().sprite = this.normalSprite;
	}

	public virtual void OnMouseDown(){

	}

	public void show (bool b){
		gameObject.GetComponent<SpriteRenderer>().enabled = b;
		gameObject.GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.FindChild("TitleButton").GetComponent<TextMeshPro>().enabled = b;
	}

	public void setText (string s){
		gameObject.transform.FindChild("TitleButton").GetComponent<TextMeshPro>().text = s;
	}
}