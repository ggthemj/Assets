using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

	private float angle;
	private float speed;
	private Quaternion target;
	public bool toShowLoading;
	float timer;

	// Use this for initialization
	void Awake()
	{
		this.show(false);
		this.speed = 300.0f;
		this.angle = 0f;
		this.toShowLoading=false;
		this.timer = 0f;
	}
	
	public void addTime (float f) {
		this.timer+=f;
		this.angle = (this.speed * this.timer)%360f;
		this.target = Quaternion.Euler (0f,this.angle, 0f);
		gameObject.transform.FindChild("LoadingIcon").transform.rotation = target;
	}

	public void showLoading(){
		this.timer = 0f;
		this.show(true);
		this.toShowLoading = true;
	}

	public void hideLoading(){
		this.show(false);
		this.toShowLoading = false;
	}

	public void show(bool b){
		gameObject.transform.FindChild("LoadingIcon").GetComponent<SpriteRenderer>().enabled = b;
		gameObject.transform.FindChild("LoadingBackground").GetComponent<SpriteRenderer>().enabled = b;
	}
}
