using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public static float startTime;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {

			PlayerPrefs.SetString("Checkpoint",Application.loadedLevelName);

			//print (CameraFollow.level+" completed. ");

			PlayerPrefs.SetInt("Checkscore",PlayerPrefs.GetInt("Checkscore")+(int)(Time.time-startTime));
			//print("Time: "+(int)(Time.time-startTime));

			if(Application.loadedLevelName=="3_Surface"){
				CameraFollow.justEnded=true;

				// updating best score
				if(PlayerPrefs.HasKey("BestScore")){
					if(PlayerPrefs.GetInt("BestScore")>PlayerPrefs.GetInt("Checkscore"))
						PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));
				}
				else PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));

				// all the rest is set in camerafollow pause()

				// removing the current score (leaving only highscore)
				PlayerPrefs.DeleteKey("Checkpoint");
				PlayerPrefs.DeleteKey("Checkscore");
			}
			else Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
