/*

	Camera's events.
	Updated 2015-7-28 12:24 by Mikko
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraFollow : MonoBehaviour {

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

	private bool justStarted = true;
	//public static string level=Application.loadedLevelName;

	// Use this for initialization
	void Start(){
		//print ("Best time for this level: " + PlayerPrefs.GetInt ("Checkscore"));

		PauseMenu();
		txtPausemenuTitle.text = Application.loadedLevelName;
		btnRestart.SetActive (false);

		// game starts
		NextLevel.startTime=Time.time;

		PlayerMove.dead=false;
		//Time.timeScale=1;
		//Sets variables for max and min bounds which camera cannot follow past and sets following bool to true so it follows
		_min=Bounds.bounds.min;
		_max=Bounds.bounds.max;
		Following=true;
	}

	// Update is called once per frame
	void Update(){
		//Starts by checking if player is dead or not
		if (PlayerMove.dead == false) {
		
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
			panel.SetActive (true);
			txtPausemenuTitle.text="Game over";
			btnContinue.SetActive(false);
		}
		//Keeps checking if stuff in PauseMenu(); is happening
		if (Input.GetKeyDown(KeyCode.Escape))
			PauseMenu();

		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
			GetComponent<Camera> ().orthographicSize = Mathf.Max(GetComponent<Camera> ().orthographicSize-1, 3);
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) // backward
			GetComponent<Camera> ().orthographicSize = Mathf.Min(GetComponent<Camera> ().orthographicSize+1, 4);
	}

	public void PauseMenu(){
		//With escape key opens up the pause menu and pauses the game
		if (Input.GetKeyDown(KeyCode.Escape)||justStarted){

			if(justStarted){
				txtPausemenuTitle.text = Application.loadedLevelName;
				txtContinue.text="Start";
				btnRestart.SetActive (false);
			}

			if (panel.activeSelf && !PlayerMove.dead)
				ResumeGame();
			else{
				Time.timeScale=0;
				panel.SetActive(true);
			}
			if(justStarted){
				if (Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Return)){
					txtPausemenuTitle.text = "Pause";
					txtContinue.text="Continue";
					btnRestart.SetActive (true);
					justStarted=false;
					panel.SetActive(false);
				}
			}
		}
	}

	//Button is linked to this and when pressing continue in the pause menu it continues the game
	public void ResumeGame(){
		panel.SetActive(false);
		Time.timeScale=1;
	}

	public void EnterMenu(){
		RestartLevel();
		Application.LoadLevel("0_Menu");
	}
	public void RestartLevel(){
		Application.LoadLevel(Application.loadedLevelName); // need to change it for any next level somehow
	}
}