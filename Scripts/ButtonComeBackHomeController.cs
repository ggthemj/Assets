using System;

public class ButtonComeBackHomeController:ButtonController
{
	public override void OnMouseDown(){
		AppModel.instance.hitCBHomeButton();
	}
}