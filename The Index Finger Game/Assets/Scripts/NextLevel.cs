using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			PlayerPrefs.SetString("Checkpoint",CameraFollow.level);
			//PlayerPrefs.SetString("Checkscore",score);

			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
