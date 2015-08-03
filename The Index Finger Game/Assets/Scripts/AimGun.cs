using UnityEngine;
using System.Collections;

public class AimGun : MonoBehaviour {
	public Transform Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector2 Difference = (Player.transform.position - transform.position);
		Difference.Normalize();
		float rotateZ = Mathf.Atan2 (Difference.y, Difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, -rotateZ);

		//Checks out where the enemy is facing and then makes the gun arm rotate accordingly.
		if (Enemy.facingLeft == true) 
		{
			transform.rotation = Quaternion.Euler (0f, 0f, -rotateZ);
		} 
		else 
		{
			transform.rotation = Quaternion.Euler (0f, 0f, rotateZ);
		}
	}
}
