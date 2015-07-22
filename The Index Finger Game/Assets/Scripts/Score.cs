using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highscore;

	static public void AddPoint()
	{
		score++;

		if (score > highscore) 
		{
			highscore = score;
		}

	}

	void Start()
	{
		highscore = PlayerPrefs.GetInt ("highscore");
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt ("highscore", highscore);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "Score: " + score + "\n High Score:" +highscore;
	}
}
