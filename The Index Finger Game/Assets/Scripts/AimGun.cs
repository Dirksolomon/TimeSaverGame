using UnityEngine;
using System.Collections;

public class AimGun : MonoBehaviour {
	public Transform Player;
	private float nextShot = 0.0f;
	private float interval = 1f;

	public Transform BulletPrefab;

	public LayerMask notToHit;
	Transform firePoint;
	// Use this for initialization
	void Start () 
	{
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) 
		{
			Debug.LogError("No firepoint");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 Difference = (Player.transform.position - transform.position);
		Difference.Normalize();
		float rotateZ = Mathf.Atan2 (Difference.y, Difference.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler (0f, 0f, -rotateZ);

		//Checks out where the enemy is facing and then makes the gun arm rotate accordingly.
		if (Enemy.isFacingLeft == true) 
		{
			this.transform.localScale = new Vector2(-1,-1);
			transform.rotation = Quaternion.Euler (0f, 0f, rotateZ);
		} 
		else if (Enemy.isFacingLeft == false)
		{
			transform.rotation = Quaternion.Euler (0f, 0f, -rotateZ);
		}
		if (Time.time >= nextShot) 
		{
			nextShot = Time.time + interval;
			Shoot ();

		}

	}

	void Shoot()
	{
			Instantiate (BulletPrefab, firePoint.position, firePoint.rotation);
	}
}
