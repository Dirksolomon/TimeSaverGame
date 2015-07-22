using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			//Move.dead = true;
			//Move.deathcooldown = 0.5f;
			KeyboardMove.dead = true;
		}
	}
}
