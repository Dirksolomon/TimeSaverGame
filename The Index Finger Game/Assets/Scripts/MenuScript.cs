/*
	Start menu script.
	Updated 2015-7-28 12:19 by Mikko
*/
using UnityEngine;
using System.Collections;

public class MenuScript:MonoBehaviour{

	public GameObject btnContinue;
	public GameObject pnlAbout;
	public GameObject pnlExit;

	public bool aboutShown=false;
	public bool exitShown=false;

	// Continuing game from the last checkpoint
	public void ContinueGame(){
		Application.LoadLevel(PlayerPrefs.GetString("CheckPoint")); // continue game
	}

	// Starting the new game
	public void StartNewGame(){
		Application.LoadLevel("1_Level"); // new game
	}

	// About the game
	public void ShowAboutGame(){
		pnlAbout.SetActive(true);
	}
	public void HideAboutGame(){
		pnlAbout.SetActive(false);
	}

	// Exit the game
	public void ShowExitGame(){
		pnlExit.SetActive(true);
	}
	public void HideExitGame(){
		pnlExit.SetActive(false);
	}

	// Quitting the game
	public void QuitGame(){
		Application.Quit();
	}

	// Use this for initialization
	void Start(){
		if (!PlayerPrefs.HasKey ("CheckPoint"))
			btnContinue.SetActive(false);
	}
	// Update is called once per frame
	void Update(){
		if(aboutShown)
			if(Input.GetKey(KeyCode.Escape))
			   HideAboutGame();
	   if(exitShown)
	   		if(Input.GetKey(KeyCode.Escape))
			   HideExitGame();
	}
}