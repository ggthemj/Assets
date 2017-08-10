using System;
using UnityEngine;

public class BigCardSkillController:MonoBehaviour
{
	public int id ;

	void Awake(){

	}

	void OnMouseOver(){
		gameObject.transform.Find("Title").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Description").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Niveau").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	void OnMouseExit(){
		gameObject.transform.Find("Title").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Description").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Niveau").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	void OnMouseDown(){
		AppModel.instance.hitBigCardSkill(this.id);
	}
}