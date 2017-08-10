using System;
using UnityEngine;
using TMPro;

public class SkillCardController : MonoBehaviour
{
	void Awake()
	{
		this.show(false);
	}

	public void show(bool b){
		gameObject.GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("Logo").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("Title").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.FindChild("Description").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.FindChild("Niveau").GetComponent<MeshRenderer>().enabled = b;
	}

	public void updateInfos(string name, Sprite s, int level, string description){
		gameObject.transform.FindChild("Title").GetComponent<TextMeshPro>().text = name;
		gameObject.transform.FindChild("Logo").GetComponent<SpriteRenderer>().sprite = s;
		gameObject.transform.FindChild("Description").GetComponent<TextMeshPro>().text = description;
		gameObject.transform.FindChild("Niveau").GetComponent<TextMeshPro>().text = AppModel.instance.getWording(6)+" "+level+"/5";
	}
}