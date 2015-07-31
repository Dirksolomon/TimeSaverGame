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
		Vector2 LookAtPlayer = (Player.transform.position - transform.position).normalized;
		float rotateZ = Mathf.Atan2 (LookAtPlayer.y, LookAtPlayer.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotateZ + 90);
	}
}
