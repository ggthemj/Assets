using System;
using UnityEngine;
using TMPro;

public class CaracBigCardController:MonoBehaviour
{
	public int id ;

	void Awake(){

	}

	void OnMouseOver(){
		gameObject.transform.Find("Icon").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Value").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	void OnMouseExit(){
		gameObject.transform.Find("Icon").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Value").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	void OnMouseDown(){
		AppModel.instance.hitBigCardSkill(this.id);
	}
}