/*
	Start menu script.
	Updated 2015-7-28 12:19 by Mikko
*/
using UnityEngine;
using System.Collections;

public class MenuScript:MonoBehaviour{

	public GameObject btnContinue;

	public void StartNewGame()	{
		Application.LoadLevel("1_Game"); // new game
	}
	public void ContinueGame()	{
		Application.LoadLevel(PlayerPrefs.GetString("CheckPoint")); // continue game
	}
	public void QuitGame(){
		Application.Quit();
	}

	// Use this for initialization
	void Start(){
		if (!PlayerPrefs.HasKey ("CheckPoint"))
			btnContinue.SetActive(false);
	}
	// Update is called once per frame
	void Update(){}
}