using System;
using UnityEngine;
using TMPro;
public class ZoneCardController:MonoBehaviour
{
	public int idCard;

	void Awake(){

	}

	void OnMouseOver(){
		gameObject.transform.Find("LifeIcon").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("SpeedIcon").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Icon0").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Icon1").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Icon2").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Icon3").GetComponent<SpriteRenderer>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("LifeValue").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("SpeedValue").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
		gameObject.transform.Find("Niveau").GetComponent<TextMeshPro>().color = new Color(71f/255f, 150f/255f, 189f/255f, 1f);
	}

	void OnMouseExit(){
		gameObject.transform.Find("LifeIcon").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("SpeedIcon").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Icon0").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Icon1").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Icon2").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Icon3").GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("LifeValue").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("SpeedValue").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
		gameObject.transform.Find("Niveau").GetComponent<TextMeshPro>().color = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
	}

	void OnMouseDown(){
		HomeManager.instance.hitCard(this.idCard);
	}
}