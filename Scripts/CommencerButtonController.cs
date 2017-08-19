using System;

public class CommencerButtonController:ButtonController
{
	public override void OnMouseDown(){
		PregameManager.instance.launchGame();	
	}
}