/**
	Author: Mikhail Timofeev and Jukka Holopainen
	Updated: 6.8.2015
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript:MonoBehaviour{
	

	public GameObject btnContinue;
	public GameObject pnlControls;
	public GameObject pnlAchievements;
	public Text txtAchievements;
	public Text txtBestScore;
	public GameObject pnlCredits;
	public GameObject pnlExit;

	public bool continuable=true;
	public bool controlsShown=false;
	public bool achievementsShown=false;
	public bool creditsShown=false;
	public bool exitShown=false;

	// Continuing game from the last checkpoint
	public void ContinueGame(){
		Application.LoadLevel(PlayerPrefs.GetString("Checkpoint")); // continue game
	}

	// Starting the new game
	public void StartNewGame(){
		PlayerPrefs.SetInt ("Checkscore", 0);

		Application.LoadLevel("1. Basement"); // new game
		NewPlayerMove.dead = false;
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

	// Game achievements
	public void ShowGameAchievements(){
		if (PlayerPrefs.HasKey ("Achievements")) {
			txtAchievements.text = PlayerPrefs.GetString ("Achievements");
			txtBestScore.text="Best time: "+PlayerPrefs.GetInt ("BestScore")+" seconds.\nCan you do it faster?";
		}
		achievementsShown = true;
		pnlAchievements.SetActive(true);
	}
	public void HideGameAchievements(){
		achievementsShown = false;
		pnlAchievements.SetActive(false);
	}

	// About the game
	public void ShowGameCredits(){
		creditsShown = true;
		pnlCredits.SetActive(true);
	}
	public void HideGameCredits(){
		creditsShown = false;
		pnlCredits.SetActive(false);
	}

	// Exit the game
	public void ShowExitGame(){
		exitShown = true;
		pnlExit.SetActive(true);
	}
	public void HideExitGame(){
		exitShown = false;
		pnlExit.SetActive(false);
	}

	// Reset statistics
	public void ResetStats(){
		PlayerPrefs.DeleteAll ();
		txtAchievements.text="These did not make for the final product.";
		txtBestScore.text="The scoring system by timer did not make the cut! \nPress Reset button to reset game continue though.";
		ShowGameAchievements ();
		continuable = false;
		btnContinue.SetActive (false);
	}

	// Quitting the game
	public void QuitGame(){
		Application.Quit();
	}

	// Use this for initialization
	void Start(){
		if (!PlayerPrefs.HasKey ("Checkpoint")) {
			continuable = false;
			btnContinue.SetActive (false);
		}
		if (PlayerPrefs.HasKey ("JustFinished")) {
			PlayerPrefs.DeleteKey("JustFinished");
			ShowGameAchievements();
			ShowGameCredits();
		}

	}
	// Update is called once per frame
	void Update(){

		// Escape key closes the window if it is open
		if (creditsShown) {
			if (
				Input.GetKeyDown (KeyCode.Escape) ||
				Input.GetKeyDown (KeyCode.Return)
			)
				HideGameCredits ();
		}
		else if (controlsShown) {
			if (
				Input.GetKeyDown (KeyCode.Escape) ||
				Input.GetKeyDown (KeyCode.Return)
			)
				HideGameControls ();
		}
		else if(achievementsShown) {
			if (
				Input.GetKeyDown (KeyCode.Escape) ||
				Input.GetKeyDown (KeyCode.Return)
				)
				HideGameAchievements ();
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