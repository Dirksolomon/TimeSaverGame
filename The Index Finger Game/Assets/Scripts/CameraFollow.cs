using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform Player;

	public Vector2 marg, smooth;

	public BoxCollider2D Bounds;

	private Vector3 _min, _max;

	public bool Following {get; set;}

	public GameObject panel;

	// Use this for initialization
	void Start () 
	{
		//Sets variables for max and min bounds which camera cannot follow past and sets following bool to true so it follows
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		Following = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Starts by checking if player is dead or not
		if (KeyboardMove.dead == false) {
		
			var x = transform.position.x;
			var y = transform.position.y;

			if (Following) {
				if (Mathf.Abs (x - Player.position.x) > marg.x)
					x = Mathf.Lerp (x, Player.position.x, smooth.x * Time.deltaTime);

				if (Mathf.Abs (y - Player.position.y) > marg.y)
					y = Mathf.Lerp (y, Player.position.y, smooth.y * Time.deltaTime);

			}

			var cameraWidth = GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);

			x = Mathf.Clamp (x, _min.x + cameraWidth, _max.x - cameraWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);

			transform.position = new Vector3 (x, y, transform.position.z);
		}
		//Keeps checking if stuff in PauseMenu(); is happening
		PauseMenu ();
	}
	public void PauseMenu()
	{
		//With escape key opens up the pause menu and pauses the game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
			panel.SetActive(true);
		}
	}
	//Button is linked to this and when pressing continue in the pause menu it continues the game
	public void ResumeGame()
	{
		Time.timeScale = 1;
		panel.SetActive(false);
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
	public void EnterMenu()
	{
		Application.LoadLevel ("0_Menu");
	}
}
