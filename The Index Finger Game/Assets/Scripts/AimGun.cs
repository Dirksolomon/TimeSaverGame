using UnityEngine;
using System.Collections;

public class AimGun : MonoBehaviour {
	//Transform variable for player characters transform
	private Transform Player;
	//For shooting interval
	private float nextShot = 0.0f;
	private float interval = 1f;
	//Audio variable
	private AudioSource gunshot;
	//Bullet prefab variable
	public Transform BulletPrefab;
	
	Transform firePoint;
	// Use this for initialization
	void Start () 
	{
		//Gets the audioclip which is to be played when gun shoots.
		gunshot = gameObject.GetComponent<AudioSource> ();
		//Sets player objects transform into variable
		Player = GameObject.Find ("Character").transform;

		//Finds the firepoint from which bullets fly off
		firePoint = transform.FindChild ("FirePoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//This pretty much checks out players position by comparing it to the guns position
		Vector2 Difference = (Player.transform.position - transform.position);
		Difference.Normalize();
		float rotateZ = Mathf.Atan2 (Difference.y, Difference.x) * Mathf.Rad2Deg;

		//Checks out where the enemy is facing and then makes the gun arm rotate accordingly with its firepoint.
		if (Enemy.isFacingLeft == true) 
		{
			transform.rotation = Quaternion.Euler (0f, 0f, -rotateZ);
			firePoint.rotation = Quaternion.Euler (0f, 0f, rotateZ);
		} 
		if (Enemy.isFacingLeft == false)
		{
			transform.rotation = Quaternion.Euler (0f, 0f, rotateZ);
			firePoint.rotation = Quaternion.Euler (0f, 0f, rotateZ);
		}
		//Timer for shooting after a slight interval
		if (Time.time >= nextShot) 
		{
			nextShot = Time.time + interval;
			Shoot ();

		}

	}
	//Shoot function that instantiates the prefab and plays audio
	void Shoot()
	{
			gunshot.Play ();
			Instantiate (BulletPrefab, firePoint.position, firePoint.rotation);
	}
}
