using System;


public class ConnectButtonController:ButtonController
{
	public ConnectButtonController ()
	{

	}

	public override void OnMouseDown(){
		AuthentManager.instance.launchHome();	
	}
}