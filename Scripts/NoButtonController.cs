using System;

public class NoButtonController:ButtonController
{
	public override void OnMouseDown(){
		AppModel.instance.hitNoButton();
	}
}