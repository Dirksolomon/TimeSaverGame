using UnityEngine;
using System.Collections;

public class VictoryPopUp : MonoBehaviour {
	
	void Update () {
		if (Wingame.victory == 1) {
						GetComponent<GUITexture> ().enabled = true;
				}
	}
}
