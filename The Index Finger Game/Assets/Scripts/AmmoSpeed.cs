using UnityEngine;
using System.Collections;

public class AmmoSpeed : MonoBehaviour {

	public int moveSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			//Makes the ammo travel
			transform.Translate (Vector2.right * Time.deltaTime * moveSpeed * 1);
			//Destroys the ammo after 1 tick
			Destroy (gameObject, 1);

	}
}
