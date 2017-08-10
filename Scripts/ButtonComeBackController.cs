using System;

public class ButtonComeBackController:ButtonController
{
	public override void OnMouseDown(){
		AppModel.instance.hitCBButton();
	}
}