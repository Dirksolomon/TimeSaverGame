using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
