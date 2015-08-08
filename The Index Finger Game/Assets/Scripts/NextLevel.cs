using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public static float startTime;

	//Fade out on level change and change the level.
	IEnumerator ChangeLevel()
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel + 1);
	}


	void OnTriggerEnter2D(Collider2D collider)
	{	//Checks if the player enters the trigger collider.
		if (collider.tag == "Player") 
			{
			//Runs ChangeLevel
			StartCoroutine(ChangeLevel());

			//The time counting seemed kind of buggy and caused some issues at points so I disabled it for now

			/*PlayerPrefs.SetInt("Checkscore",(int)(Time.time-startTime));

			if(Application.loadedLevelName=="3. Surface"){
				PlayerPrefs.SetInt("JustFinished",1);
				NewCameraFollow.justEnded=true;

				// updating best score
				if(PlayerPrefs.HasKey("BestScore")){
					if(PlayerPrefs.GetInt("BestScore")>PlayerPrefs.GetInt("Checkscore"))
						PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));
				}
				else PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("Checkscore"));
				if(PlayerPrefs.HasKey("Complitions"))
					PlayerPrefs.SetInt("Complitions",PlayerPrefs.GetInt("Complitions")+1);
				else PlayerPrefs.SetInt("Complitions",1);
				   PlayerPrefs.SetString("Achievements","Games completed: "+PlayerPrefs.GetInt("Complitions")+".");*/
				// all the rest is set in camerafollow pause()
			}
		}
	}