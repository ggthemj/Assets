using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class PreGamePopUpController : MonoBehaviour
{
	public Sprite[] preMatchScreenAvatars;

	private float angle;
	private float speed;
	private Quaternion target;

	private bool isPreMatchScreen;

	private float preMatchScreenSpeed;
	private float preMatchScreenRatio;

	private GameObject[] myCards;
	private GameObject[] hisCards;

	private GameObject myName;
	private GameObject hisName;
	private GameObject vs;

	private Vector3[] myCardsStartPosition;
	private float[] myCardsCurrentPosition;
	private bool[] toAnimateMyCards;
	private Vector3[] myCardsEndPosition;

	private Vector3[] hisCardsStartPosition;
	private float[] hisCardsCurrentPosition;
	private bool[] toAnimateHisCards;
	private Vector3[] hisCardsEndPosition;

	private Vector3 myNameStartPosition;
	private float myNameCurrentPosition;
	private bool toAnimateMyName;
	private Vector3 myNameEndPosition;

	private Vector3 hisNameStartPosition;
	private float hisNameCurrentPosition;
	private bool toAnimateHisName;
	private Vector3 hisNameEndPosition;

	private bool toAnimatePreMatchLoadingScreen;
	private bool toRewindPreMatchLoadingScreen;
	private bool toShowLoading;

	void Awake()
	{
		this.speed = 300.0f;
		this.preMatchScreenSpeed=3f;
		this.preMatchScreenRatio = 0.3f;

		this.angle = 0f;
		this.myCards=new GameObject[4];
		this.hisCards=new GameObject[4];
		for(int i=0;i<4;i++)
		{
			this.myCards[i]=this.gameObject.transform.FindChild("myCard"+i).gameObject;
			this.hisCards[i]=this.gameObject.transform.FindChild("hisCard"+i).gameObject;
		}
		this.myName= this.gameObject.transform.FindChild("myName").gameObject;
		this.hisName=this.gameObject.transform.FindChild("hisName").gameObject;
		this.vs=this.gameObject.transform.FindChild("VS").gameObject;
	}
	void Update()
	{
		if(this.toAnimatePreMatchLoadingScreen)
		{
			bool isOver=true;

			if(this.toAnimateMyName)
			{
				this.myNameCurrentPosition=this.myNameCurrentPosition+this.preMatchScreenSpeed*Time.deltaTime;
				if(this.myNameCurrentPosition>this.preMatchScreenRatio && !this.toAnimateMyCards.Contains(true))
				{
					this.toAnimateMyCards[0]=true;
				}
				if(this.myNameCurrentPosition>1f)
				{
					this.myNameCurrentPosition=1f;
					this.toAnimateMyName=false;
				}
				else
				{
					isOver=false;
				}
				Vector3 myNamePosition=this.myName.transform.localPosition;
				myNamePosition.x=this.myNameStartPosition.x + (this.myNameEndPosition.x-this.myNameStartPosition.x)*this.myNameCurrentPosition;
				this.myName.transform.localPosition=myNamePosition;
			}
			if(this.toAnimateHisName)
			{
				this.hisNameCurrentPosition=this.hisNameCurrentPosition+this.preMatchScreenSpeed*Time.deltaTime;
				if(this.hisNameCurrentPosition>this.preMatchScreenRatio && !this.toAnimateHisCards.Contains(true))
				{
					this.toAnimateHisCards[0]=true;
				}
				if(this.hisNameCurrentPosition>1f)
				{
					this.hisNameCurrentPosition=1f;
					this.toAnimateHisName=false;
				}
				else
				{
					isOver=false;
				}
				Vector3 hisNamePosition=this.hisName.transform.localPosition;
				hisNamePosition.x=this.hisNameStartPosition.x + (this.hisNameEndPosition.x-this.hisNameStartPosition.x)*this.hisNameCurrentPosition;
				this.hisName.transform.localPosition=hisNamePosition;
			}
			for(int i=0;i<4;i++)
			{
				if(this.toAnimateMyCards[i])
				{
					this.myCardsCurrentPosition[i]=this.myCardsCurrentPosition[i]+this.preMatchScreenSpeed*Time.deltaTime;
					if(this.myCardsCurrentPosition[i]>this.preMatchScreenRatio && i<3 && !this.toAnimateMyCards[i+1])
					{
						this.toAnimateMyCards[i+1]=true;
					}
					if(this.myCardsCurrentPosition[i]>1f)
					{
						this.myCardsCurrentPosition[i]=1f;
						this.toAnimateMyCards[i]=false;
					}
					else
					{
						isOver=false;
					}
					Vector3 myCardPosition=this.myCards[i].transform.localPosition;
					myCardPosition.x=this.myCardsStartPosition[i].x + (this.myCardsEndPosition[i].x-this.myCardsStartPosition[i].x)*this.myCardsCurrentPosition[i];
					this.myCards[i].transform.localPosition=myCardPosition;
				}
				if(this.toAnimateHisCards[i])
				{
					this.hisCardsCurrentPosition[i]=this.hisCardsCurrentPosition[i]+this.preMatchScreenSpeed*Time.deltaTime;
					if(this.hisCardsCurrentPosition[i]>this.preMatchScreenRatio && i<3 && !this.toAnimateHisCards[i+1])
					{
						this.toAnimateHisCards[i+1]=true;
					}
					if(this.hisCardsCurrentPosition[i]>1f)
					{
						this.hisCardsCurrentPosition[i]=1f;
						this.toAnimateHisCards[i]=false;
					}
					else
					{
						isOver=false;
					}
					Vector3 hisCardPosition=this.hisCards[i].transform.localPosition;
					hisCardPosition.x=this.hisCardsStartPosition[i].x + (this.hisCardsEndPosition[i].x-this.hisCardsStartPosition[i].x)*this.hisCardsCurrentPosition[i];
					this.hisCards[i].transform.localPosition=hisCardPosition;
				}
			}
			if(isOver)
			{
				this.toAnimatePreMatchLoadingScreen=false;
				this.vs.transform.localPosition=new Vector3(0f,0f,0f);
				this.vs.SetActive(true);
				StartCoroutine(this.toRewind());
			}
		}
		if(this.toRewindPreMatchLoadingScreen)
		{
			bool isOver=true;

			for(int i=0;i<4;i++)
			{
				if(this.toAnimateMyCards[3-i])
				{
					this.myCardsCurrentPosition[3-i]=this.myCardsCurrentPosition[3-i]-this.preMatchScreenSpeed*Time.deltaTime;
					if(this.myCardsCurrentPosition[3-i]<(1-this.preMatchScreenRatio) && (3-i>0) && !this.toAnimateMyCards[2-i])
					{
						this.toAnimateMyCards[2-i]=true;
					}
					else if(this.myCardsCurrentPosition[3-i]<(1-this.preMatchScreenRatio) && 3-i==0 && !this.toAnimateMyName)
					{
						this.toAnimateMyName=true;
					}
					if(this.myCardsCurrentPosition[3-i]<0f)
					{
						this.myCardsCurrentPosition[3-i]=0f;
						this.toAnimateMyCards[3-i]=false;
					}
					else
					{
						isOver=false;
					}
					Vector3 myCardPosition=this.myCards[3-i].transform.localPosition;
					myCardPosition.x=this.myCardsStartPosition[3-i].x + (this.myCardsEndPosition[3-i].x-this.myCardsStartPosition[3-i].x)*this.myCardsCurrentPosition[3-i];
					this.myCards[3-i].transform.localPosition=myCardPosition;
				}
				if(this.toAnimateHisCards[3-i])
				{
					this.hisCardsCurrentPosition[3-i]=this.hisCardsCurrentPosition[3-i]-this.preMatchScreenSpeed*Time.deltaTime;
					if(this.hisCardsCurrentPosition[3-i]<(1-this.preMatchScreenRatio) && (3-i>0) && !this.toAnimateHisCards[2-i])
					{
						this.toAnimateHisCards[2-i]=true;
					}
					else if(this.hisCardsCurrentPosition[3-i]<(1-this.preMatchScreenRatio) && 3-i==0 && !this.toAnimateHisName)
					{
						this.toAnimateHisName=true;
					}
					if(this.hisCardsCurrentPosition[3-i]<0f)
					{
						this.hisCardsCurrentPosition[3-i]=0f;
						this.toAnimateHisCards[3-i]=false;
					}
					else
					{
						isOver=false;
					}
					Vector3 myCardPosition=this.hisCards[3-i].transform.localPosition;
					myCardPosition.x=this.hisCardsStartPosition[3-i].x + (this.hisCardsEndPosition[3-i].x-this.hisCardsStartPosition[3-i].x)*this.hisCardsCurrentPosition[3-i];
					this.hisCards[3-i].transform.localPosition=myCardPosition;
				}
			}
			if(this.toAnimateMyName)
			{
				this.myNameCurrentPosition=this.myNameCurrentPosition-this.preMatchScreenSpeed*Time.deltaTime;
				if(this.myNameCurrentPosition<0f)
				{
					this.myNameCurrentPosition=0f;
					this.toAnimateMyName=false;
				}
				else
				{
					isOver=false;
				}
				Vector3 myNamePosition=this.myName.transform.localPosition;
				myNamePosition.x=this.myNameStartPosition.x + (this.myNameEndPosition.x-this.myNameStartPosition.x)*this.myNameCurrentPosition;
				this.myName.transform.localPosition=myNamePosition;
			}
			if(this.toAnimateHisName)
			{
				this.hisNameCurrentPosition=this.hisNameCurrentPosition-this.preMatchScreenSpeed*Time.deltaTime;
				if(this.hisNameCurrentPosition<0f)
				{
					this.hisNameCurrentPosition=0f;
					this.toAnimateHisName=false;
				}
				else
				{
					isOver=false;
				}
				Vector3 hisNamePosition=this.hisName.transform.localPosition;
				hisNamePosition.x=this.hisNameStartPosition.x + (this.hisNameEndPosition.x-this.hisNameStartPosition.x)*this.hisNameCurrentPosition;
				this.hisName.transform.localPosition=hisNamePosition;
			}
			if(isOver)
			{
				this.toRewindPreMatchLoadingScreen = false ;
				gameObject.transform.Find("background").GetComponent<SpriteRenderer>().enabled=false;
			}
		}
		if(this.toShowLoading)
		{
			this.angle = this.angle + this.speed * Time.deltaTime;
			this.target = Quaternion.Euler (0f,this.angle, 0f);
			this.gameObject.transform.FindChild("loadingCircle").transform.rotation = target;
		}
	}

	public void changeLoadingScreenLabel(string label)
	{
		this.gameObject.transform.FindChild ("title").GetComponent<TextMeshPro> ().text = label;
	}
	public void displayButton(bool value)
	{
		this.gameObject.transform.FindChild ("button").gameObject.SetActive (value);
	}
	public void launchPreMatchLoadingScreen()
	{
		this.initializePreMatchLoadingScreen();
		this.resize();
		this.toAnimatePreMatchLoadingScreen=true;
		this.toShowLoading=false;
	}
	public void reset()
	{
		this.isPreMatchScreen=false;
		this.toAnimatePreMatchLoadingScreen=false;
		this.toRewindPreMatchLoadingScreen=false;
		this.toShowLoading=true;
		for(int i=0;i<4;i++)
		{
			this.myCards[i].SetActive(false);
			this.hisCards[i].SetActive(false);
		}
		this.myName.SetActive(false);
		this.hisName.SetActive(false);
		this.vs.SetActive(false);
		this.gameObject.transform.FindChild("loadingCircle").gameObject.SetActive(true);
		this.gameObject.transform.FindChild("button").gameObject.SetActive(true);
		this.gameObject.transform.FindChild("title").gameObject.SetActive(true);
	}
	private void initializePreMatchLoadingScreen()
	{
		this.isPreMatchScreen=true;
		this.myCardsCurrentPosition=new float[4];
		this.hisCardsCurrentPosition=new float[4];
		this.myCardsStartPosition=new Vector3[4];
		this.hisCardsStartPosition=new Vector3[4];
		this.myCardsEndPosition=new Vector3[4];
		this.hisCardsEndPosition=new Vector3[4];
		this.toAnimateMyCards=new bool[4];
		this.toAnimateHisCards=new bool[4];
		for(int i=0;i<4;i++)
		{
			this.myCards[i].transform.FindChild("Avatar").GetComponent<SpriteRenderer>().sprite=this.preMatchScreenAvatars[AppModel.instance.myTeam[i]];
			this.myCards[i].SetActive(true);
			this.hisCards[i].transform.FindChild("Avatar").GetComponent<SpriteRenderer>().sprite=this.preMatchScreenAvatars[GameManager.instance.getHisUnitID(i)];
			this.hisCards[i].SetActive(true);
			this.myCardsCurrentPosition[i]=0f;
			this.hisCardsCurrentPosition[i]=0f;
		}
		this.toAnimateMyName=true;
		this.toAnimateHisName=true;
		this.myNameCurrentPosition=0f;
		this.hisNameCurrentPosition=0f;
		this.myName.SetActive(true);
		this.hisName.SetActive(true);
		this.vs.transform.GetComponent<TextMeshPro>().text=AppModel.instance.getWording(86);
		this.vs.SetActive(false);
		this.gameObject.transform.FindChild("loadingCircle").gameObject.SetActive(false);
		this.gameObject.transform.FindChild("button").gameObject.SetActive(false);
		this.gameObject.transform.FindChild("title").gameObject.SetActive(false);
		this.myName.GetComponent<TextMeshPro>().text=AppModel.instance.userData.name.ToUpper();
		this.hisName.GetComponent<TextMeshPro>().text=GameManager.instance.hisName.ToUpper();
	}
	public void resize()
	{
		float w = AppModel.instance.widthScreen;
		float h = AppModel.instance.heightScreen;
		this.gameObject.transform.position = new Vector3 (0f, 0f, 0f);

		if(this.isPreMatchScreen)
		{
			Vector3 myCardAvatarLocalPosition = new Vector3();
			Vector3 hisCardAvatarLocalPosition = new Vector3();
			for(int i=0;i<4;i++)
			{
				if (Screen.width > Screen.height) {
					this.myCards [i].transform.localScale = new Vector3 (1f, 1f, 1f);
					this.myName.transform.localScale=new Vector3 (1f, 1f, 1f);
					this.hisName.transform.localScale=new Vector3 (1f, 1f, 1f);
					this.vs.transform.localScale=new Vector3 (1f, 1f, 1f);
				}
				else {
					this.myCards [i].transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
					this.myName.transform.localScale=new Vector3 (0.5f, 0.5f, 0.5f);
					this.hisName.transform.localScale=new Vector3 (0.5f, 0.5f, 0.5f);
					this.vs.transform.localScale=new Vector3 (0.5f, 0.5f, 0.5f);
				}
				myCardAvatarLocalPosition = this.myCards[i].transform.FindChild("Avatar").transform.localPosition;
				//myCardAvatarLocalPosition.x = 1f/(ApplicationDesignRules.flipObjectScale.x)*((ApplicationDesignRules.flipObjectWorldSize.x/2f)-this.myCards[i].transform.FindChild("Avatar").GetComponent<SpriteRenderer>().bounds.size.x/2f-1.1f);
				this.myCards[i].transform.FindChild("Avatar").transform.localPosition = myCardAvatarLocalPosition;
				//this.hisCards[i].transform.localScale=ApplicationDesignRules.flipObjectScale;
				hisCardAvatarLocalPosition = this.hisCards[i].transform.FindChild("Avatar").transform.localPosition;
				//hisCardAvatarLocalPosition.x = 1f/(ApplicationDesignRules.flipObjectScale.x)*((-ApplicationDesignRules.flipObjectWorldSize.x/2f)+this.hisCards[i].transform.FindChild("Avatar").GetComponent<SpriteRenderer>().bounds.size.x/2f+1.1f);
				this.hisCards[i].transform.FindChild("Avatar").transform.localPosition = hisCardAvatarLocalPosition;

				float verticalGap;
				float horizontalGap;
				float firstLineGap;

				if(Screen.width <= Screen.height)
				{
					verticalGap=0.2f;
					horizontalGap = 0.7f;
					firstLineGap=0.8f;
				}
				else
				{
					verticalGap=0.3f;
					horizontalGap = 1.1f;
					firstLineGap=1f;
				}
				this.myNameStartPosition=new Vector3(-3f*(10f*w/h)/2f,10f/2f-0.4f,0f);
				this.myName.transform.localPosition=this.myNameStartPosition;
				this.myNameEndPosition=new Vector3(0.2f-(10f*w/h)/2f,this.myNameStartPosition.y,0f);

				this.hisNameStartPosition=new Vector3(3f*(10f*w/h)/2f,-10f/2f+0.4f,0f);
				this.hisName.transform.localPosition=this.hisNameStartPosition;
				this.hisNameEndPosition=new Vector3(-0.2f+(10f*w/h)/2f,this.hisNameStartPosition.y,0f);

				//this.myCardsStartPosition[i]=new Vector3(-(10f*w/h)/2f-ApplicationDesignRules.flipObjectWorldSize.x/2f-i*(horizontalGap), ApplicationDesignRules.worldHeight/2f-firstLineGap-ApplicationDesignRules.flipObjectWorldSize.y/2f-i*(ApplicationDesignRules.flipObjectWorldSize.y + verticalGap),0f);
				this.myCards[i].transform.localPosition=this.myCardsStartPosition[i];
				//this.hisCardsStartPosition[i]=new Vector3(+(10f*w/h)/2f+ApplicationDesignRules.flipObjectWorldSize.x/2f+i*(horizontalGap), -ApplicationDesignRules.worldHeight/2f+firstLineGap+ApplicationDesignRules.flipObjectWorldSize.y/2f+i*(ApplicationDesignRules.flipObjectWorldSize.y + verticalGap),0f);
				this.hisCards[i].transform.localPosition=this.hisCardsStartPosition[i];
				//this.myCardsEndPosition[i]=new Vector3(-0.1f-(10f*w/h)/2f+ApplicationDesignRules.flipObjectWorldSize.x/2f-i*(horizontalGap), this.myCardsStartPosition[i].y,0f);
				//this.hisCardsEndPosition[i]=new Vector3(0.1f+(10f*w/h)/2f-ApplicationDesignRules.flipObjectWorldSize.x/2f+i*(horizontalGap), this.hisCardsStartPosition[i].y,0f);

				Vector3 myCardPosition=this.myCards[i].transform.localPosition;
				myCardPosition.x=this.myCardsStartPosition[i].x + (this.myCardsEndPosition[i].x-this.myCardsStartPosition[i].x)*this.myCardsCurrentPosition[i];
				this.myCards[i].transform.localPosition=myCardPosition;

				Vector3 hisCardPosition=this.hisCards[i].transform.localPosition;
				hisCardPosition.x=this.hisCardsStartPosition[i].x + (this.hisCardsEndPosition[i].x-this.hisCardsStartPosition[i].x)*this.hisCardsCurrentPosition[i];
				this.hisCards[i].transform.localPosition=hisCardPosition;
			}
		}
	}
	private IEnumerator toRewind()
	{
		yield return new WaitForSeconds(3.5f);
		this.vs.SetActive(false);
		this.toAnimateHisCards[3]=true;
		this.toAnimateMyCards[3]=true;
		this.toRewindPreMatchLoadingScreen=true;
	}
}


