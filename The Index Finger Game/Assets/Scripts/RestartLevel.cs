using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	public GameObject panel;
	public Text txtPausemenu;
	public GameObject btnContinue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (KeyboardMove.dead == true){
			panel.SetActive(true);
			txtPausemenu.text="Game over";
			btnContinue.SetActive(false);

			//GetComponent<GUITexture>().enabled = true;
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
