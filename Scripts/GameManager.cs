using System;

public class GameManager:SceneController
{
	public static GameManager instance;
	public int[] hisTeam;
	public string hisName;

	void Awake(){
		instance=this;
		this.hisTeam = new int[4];
		this.hisName = "";
	}

	public int getMyUnitID(int i){
		return AppModel.instance.myTeam [i];
	}

	public int getHisUnitID(int i){
		return hisTeam [i];
	}
}