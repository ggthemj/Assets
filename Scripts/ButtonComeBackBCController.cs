using System;

public class ButtonComeBackBCController:ButtonController
{
	public override void OnMouseDown(){
		AppModel.instance.hitCBBCButton();
	}
}