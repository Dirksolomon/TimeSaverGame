using UnityEngine;
using System.Collections;

public class AmmoSpeed : MonoBehaviour {

	public int moveSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Enemy.isFacingLeft == true) 
		{
			transform.Translate (Vector2.right * Time.deltaTime * moveSpeed * 1);
			Destroy (gameObject, 1);
		} 
		else if (Enemy.isFacingLeft == false)
		{
			transform.Translate (Vector2.right * Time.deltaTime * moveSpeed * 1);
			Destroy (gameObject, 1);
		}
	}
}
