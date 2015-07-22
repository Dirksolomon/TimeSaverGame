using UnityEngine;
using System.Collections;

public class Wingame : MonoBehaviour {
	public static int victory = 0;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Time.timeScale = 0;
			victory = 1;
		}
	}
}
