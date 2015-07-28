/*
	Start menu script.
	Updated 2015-7-28 12:19 by Mikko
*/
using UnityEngine;
using System.Collections;

public class MenuScript:MonoBehaviour{
	public void StartGame()	{
		Application.LoadLevel("1_Game"); // new game
	}
	public void QuitGame(){
		Application.Quit();
	}

	// Use this for initialization
	void Start(){}
	// Update is called once per frame
	void Update(){}
}