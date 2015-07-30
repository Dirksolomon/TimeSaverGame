using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform upLook;
	public Transform straightLook;
	public Transform downLook;
	public GameObject enemyGuard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//enemyGuard.transform.Translate(Vector2.right*2);
		//enemyGuard.transform.Translate(-Vector2.right*2);
		Debug.DrawRay(transform.position, upLook.transform * 0.4f, Color.red);
		if(Physics2D.Raycast(transform.position, upLook.transform, 0.4f))
		{
			Debug.Log ("Player in sight!");
		}
	}
}
