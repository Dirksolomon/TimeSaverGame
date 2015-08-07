using UnityEngine;
using System.Collections;

public class CreditScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToMenu()
	{
		Application.LoadLevel ("0. Menu");
	}


	public void ExitGame()
	{
		Application.Quit ();
	}
}
