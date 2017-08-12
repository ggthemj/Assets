using System;
using UnityEngine;
using TMPro;

public class BigCardSkillController:MonoBehaviour
{
	public int id ;

	void Awake(){

	}

	void OnMouseOver(){
		if(this.id==2){
			gameObject.transform.Find("Title").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
			gameObject.transform.Find("Description").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
			gameObject.transform.Find("Niveau").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		}
		else{
			gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		}
	}

	void OnMouseExit(){
		if(this.id==2){
			gameObject.transform.Find("Title").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
			gameObject.transform.Find("Description").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
			gameObject.transform.Find("Niveau").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
		else{
			gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		}
	}

	void OnMouseDown(){
		AppModel.instance.hitBigCardSkill(this.id);
	}

	public void show(bool b, bool t){
		gameObject.transform.Find("Title").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("Description").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("Niveau").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.Find("Logo").GetComponent<SpriteRenderer>().enabled = b & t;
		gameObject.transform.GetComponent<BoxCollider2D>().enabled = b;
		gameObject.transform.GetComponent<SpriteRenderer>().enabled = b;
	}
}