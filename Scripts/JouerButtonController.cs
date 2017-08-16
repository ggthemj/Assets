using System;

public class JouerButtonController:ButtonController
{
	public override void OnMouseDown(){
		HomeManager.instance.jouerOfficiel();	
	}
}