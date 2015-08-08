using UnityEngine;
using System.Collections;

public class CreditScreenController : MonoBehaviour {

	//Controller for the last screen so the player can press buttons quitting the game or returning to main menu

	public void ToMenu()
	{
		Application.LoadLevel ("0. Menu");
	}


	public void ExitGame()
	{
		Application.Quit ();
	}
}
