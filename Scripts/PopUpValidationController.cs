using System;
using UnityEngine;
using TMPro;

public class PopUpValidationController:MonoBehaviour
{
	bool twoChoices;

	void Awake()
	{
		this.twoChoices = false;
		this.show(false);
	}

	public void launch(bool t, string titleText, string bodyText, string yesText, string noText){
		this.twoChoices = t;
		gameObject.transform.FindChild("TitleChoice").GetComponent<TextMeshPro>().text = titleText;
		gameObject.transform.FindChild("TexteChoix").GetComponent<TextMeshPro>().text = bodyText;
		gameObject.transform.FindChild("ButtonYes").GetComponent<YesButtonController>().setText(yesText);
		gameObject.transform.FindChild("ButtonNo").GetComponent<NoButtonController>().setText(noText);
	}

	public void show(bool b){
		gameObject.transform.FindChild("LoadingBackground").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("ChoiceValidation").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("TitleChoice").GetComponent<MeshRenderer>().enabled = b;
		gameObject.transform.FindChild("TexteChoix").GetComponent<MeshRenderer>().enabled = b;
		if(this.twoChoices){
			gameObject.transform.FindChild("ButtonYes").position = new Vector3(-1.4f, -2.5f, 0f);
			gameObject.transform.FindChild("ButtonNo").GetComponent<NoButtonController>().show(b);
		}
		else{
			gameObject.transform.FindChild("ButtonYes").position = new Vector3(0f, -2.5f, 0f);
			gameObject.transform.FindChild("ButtonNo").GetComponent<NoButtonController>().show(false);
		}
		gameObject.transform.FindChild("ButtonYes").GetComponent<YesButtonController>().show(b);
	}
}