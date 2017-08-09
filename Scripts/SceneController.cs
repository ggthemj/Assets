using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public int status ;

	void Awake(){
		
	}

	public virtual void initTexts(){
		Debug.Log("Méthode initTexts non définie");
	}

	public virtual void resume(string error){
		Debug.Log("Méthode resume non définie");
	}

	public void moveToScene(string s){
		AppModel.instance.loadingScreen.hideLoading();
		SceneManager.LoadScene(s);
	}
}
