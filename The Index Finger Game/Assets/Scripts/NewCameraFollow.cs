using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewCameraFollow : MonoBehaviour {
	
	public Transform Player;
	
	public Vector2 marg, smooth;
	
	public BoxCollider2D Bounds;
	
	private Vector3 _min, _max;
	
	public bool Following {get; set;}
	
	public GameObject panel;
	
	public Text txtPausemenuTitle;
	public GameObject btnContinue;
	public Text txtContinue;
	public GameObject btnRestart;
	public Text txtInfoText;
	
	public Text txtScore;
	
	public static bool justStarted = true;
	public static bool justEnded = false;
	//public static string level=Application.loadedLevelName;
	
	// Use this for initialization
	void Start(){
		Time.timeScale = 1;
		justEnded = false;
		
		PlayerPrefs.SetString("Checkpoint",Application.loadedLevelName);
		//txtPausemenuTitle.text ="Level "+Application.loadedLevelName;
		btnRestart.SetActive (false);
		panel.SetActive (true);
		PauseMenu();
		
		// game starts
		NextLevel.startTime=PlayerPrefs.GetInt("Checkscore")-1;
		
		NewPlayerMove.dead=false;
		//Time.timeScale=1;
		//Sets variables for max and min bounds which camera cannot follow past and sets following bool to true so it follows
		_min=Bounds.bounds.min;
		_max=Bounds.bounds.max;
		Following=true;
	}
	
	// Update is called once per frame
	void Update(){
		
		txtScore.text="Time: "+(int)(NextLevel.startTime+Time.time);
		
		//Starts by checking if player is dead or not
		if (NewPlayerMove.dead == false) {
			
			var x = transform.position.x;
			var y = transform.position.y;
			
			// Camera following the player
			if (Following) {
				if (Mathf.Abs (x - Player.position.x) > marg.x)
					x = Mathf.Lerp (x, Player.position.x, smooth.x * Time.deltaTime);
				if (Mathf.Abs (y - Player.position.y) > marg.y)
					y = Mathf.Lerp (y, Player.position.y, smooth.y * Time.deltaTime);
			}
			
			
			var cameraWidth = GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);
			
			x = Mathf.Clamp (x, _min.x + cameraWidth, _max.x - cameraWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);
			
			// Camera moving to show the player
			transform.position = new Vector3 (x, y, transform.position.z);
		} else {
			Time.timeScale = 0;
			PlayerPrefs.SetInt("Checkscore",(int)(Time.time-NextLevel.startTime));
			panel.SetActive (true);
			txtPausemenuTitle.text="Perhaps another timeline will be more successful for you.";
			btnContinue.SetActive(false);
			btnRestart.SetActive(true);
		}
		
		//Keeps checking if stuff in PauseMenu(); is happening
		PauseMenu ();
		
		
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
			GetComponent<Camera> ().orthographicSize = Mathf.Max(GetComponent<Camera> ().orthographicSize-1, 7);
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) // backward
			GetComponent<Camera> ().orthographicSize = Mathf.Min(GetComponent<Camera> ().orthographicSize+1, 15);
	}
	
	public void PauseMenu(){
		//With escape key opens up the pause menu and pauses the game
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (!justEnded)
				ResumeGame ();
			else EnterMenu();
		}
		if (Input.GetKeyDown (KeyCode.Escape)||Input.GetKeyDown (KeyCode.Pause)||Input.GetKeyDown (KeyCode.Q)||justEnded){
			Time.timeScale = 0;
			// activating panel
			if(!panel.activeSelf){
				if (justStarted) {
					
				}
				else{
					if (justEnded){
						txtPausemenuTitle.text = "Keep going.";
						btnContinue.SetActive (false);
						btnRestart.SetActive (false);
						txtInfoText.text = "Your time is " +
							PlayerPrefs.GetInt ("Checkscore") +
								".\nBest time is " +
								PlayerPrefs.GetInt ("BestScore") + ".\nNice job!";
						
						// removing the current score (leaving only highscore)
						PlayerPrefs.DeleteKey("Checkpoint");
						PlayerPrefs.DeleteKey("Checkscore");
					}
					else{
						txtPausemenuTitle.text = "Patience is a virtue.";
						txtContinue.text = "Continue";
						btnContinue.SetActive (true);
						btnRestart.SetActive (true);
					}
				}
				panel.SetActive (true);
			}
			else if (!NewPlayerMove.dead&&!justEnded)
				ResumeGame ();
		}
		justStarted = false;
	}
	
	//Button is linked to this and when pressing continue in the pause menu it continues the game
	public void ResumeGame(){
		panel.SetActive(false);
		Time.timeScale=1;
	}
	
	public void EnterMenu(){
		RestartLevel();
		Application.LoadLevel("0. Menu");
	}
	public void RestartLevel(){
		Application.LoadLevel(Application.loadedLevelName); // need to change it for any next level somehow
	}
}