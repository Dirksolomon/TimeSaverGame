using UnityEngine;
using System.Collections;

public class Addpoint : MonoBehaviour {



void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Score.AddPoint();
			gameObject.SetActive(false);
		}
	}
}
