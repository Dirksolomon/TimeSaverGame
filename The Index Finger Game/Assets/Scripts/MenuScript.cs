/*
	Start menu script.
	Updated 2015-7-28 12:19 by Mikko
*/
using UnityEngine;
using System.Collections;

public class MenuScript:MonoBehaviour{

	public GameObject btnContinue;
	public GameObject pnlControls;
	public GameObject pnlAbout;
	public GameObject pnlExit;

	public bool continuable=true;
	public bool controlsShown=false;
	public bool aboutShown=false;
	public bool exitShown=false;

	// Continuing game from the last checkpoint
	public void ContinueGame(){
		Application.LoadLevel(PlayerPrefs.GetString("CheckPoint")); // continue game
	}

	// Starting the new game
	public void StartNewGame(){
		Application.LoadLevel("1_Basement"); // new game
	}

	// Controls for the game
	public void ShowGameControls(){
		controlsShown = true;
		pnlControls.SetActive(true);
	}
	public void HideGameControls(){
		controlsShown = false;
		pnlControls.SetActive(false);
	}

	// About the game
	public void ShowAboutGame(){
		aboutShown = true;
		pnlAbout.SetActive(true);
	}
	public void HideAboutGame(){
		aboutShown = false;
		pnlAbout.SetActive(false);
	}

	// Exit the game
	public void ShowExitGame(){
		print ("Please, do not go away!");
		exitShown = true;
		pnlExit.SetActive(true);
	}
	public void HideExitGame(){
		print ("Oh yeah, keep playing...");
		exitShown = false;
		pnlExit.SetActive(false);
	}

	// Quitting the game
	public void QuitGame(){
		print ("Bye.");
		Application.Quit();
	}

	// Use this for initialization
	void Start(){
		if (!PlayerPrefs.HasKey ("CheckPoint")) {
			continuable=false;
			btnContinue.SetActive (false);
		}
	}
	// Update is called once per frame
	void Update(){

		// Escape key closes the window if it is open
		if (aboutShown) {
			if (Input.GetKeyDown (KeyCode.Escape))
				HideAboutGame ();
		}
		else if(exitShown){
			if (Input.GetKeyDown (KeyCode.Escape))
				HideExitGame ();
			else if (Input.GetKeyDown (KeyCode.Return))
				QuitGame ();
		}

		else {
			// Escape key shows exit window if there is no more open windows
			if (Input.GetKeyDown (KeyCode.Escape))
				ShowExitGame ();

			// Enter acts as a press on the first menu item
			else if (Input.GetKeyDown (KeyCode.Return)){
				// Continue game if possible
				if(continuable)
					ContinueGame();
				// Else start new game
				else StartNewGame();
			}
		}
	}
}