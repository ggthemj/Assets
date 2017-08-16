using System;

public class JouerAmicalButtonController:ButtonController
{
	public override void OnMouseDown(){
		HomeManager.instance.jouerAmicalOfficiel();	
	}
}