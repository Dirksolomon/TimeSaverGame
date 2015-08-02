/**
	Autor: Mikhail Timofeev
	Updated: 2.8.2015
*/
using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public static float startTime;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {

			PlayerPrefs.SetInt("Checkscore",(int)(Time.time-startTime));

			if(Application.loadedLevelName=="3. Surface"){
				PlayerPrefs.SetInt("JustFinished",1);
				CameraFollow.justEnded=true;

				// updating best score
				if(PlayerPrefs.HasKey("BestScore")){
					if(PlayerPrefs.GetInt("BestScore")>PlayerPrefs.GetInt("Checkscore"))
						PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));
				}
				else PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));
				if(PlayerPrefs.HasKey("Complitions"))
					PlayerPrefs.SetInt("Complitions",PlayerPrefs.GetInt("Complitions")+1);
				else PlayerPrefs.SetInt("Complitions",1);
				   PlayerPrefs.SetString("Achievements","Games completed: "+PlayerPrefs.GetInt("Complitions")+".");
				// all the rest is set in camerafollow pause()
			}
			else Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}