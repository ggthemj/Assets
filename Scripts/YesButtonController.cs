using System;

public class YesButtonController:ButtonController
{
	public override void OnMouseDown(){
		AppModel.instance.hitYesButton();
	}
}