using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (KeyboardMove.dead == true) 
		{
			GetComponent<GUITexture>().enabled = true;
			Time.timeScale = 0;
		}
	}
	public void OnMouseDown()
	{
		KeyboardMove.dead = false;
		Time.timeScale = 1;
		Application.LoadLevel("1_Game");

	}
}
