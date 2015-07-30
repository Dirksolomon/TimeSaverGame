using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform upLook;
	public Transform straightLook;
	public Transform downLook;
	public GameObject enemyGuard;
	private float SightRange = 2f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 upLookPos = (upLook.transform.position - transform.position).normalized;
		Vector2 straightLookPos = (straightLook.transform.position - transform.position).normalized;
		Vector2 downLookPos = (downLook.transform.position - transform.position).normalized;
		//enemyGuard.transform.Translate(Vector2.right*2);
		//enemyGuard.transform.Translate(-Vector2.right*2);
		Debug.DrawRay(transform.position, upLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, downLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, straightLookPos * SightRange, Color.red);
		if(Physics2D.Raycast(transform.position, downLookPos, SightRange))
		{
			Debug.Log ("Player in sight!");
		}
		if (Physics2D.Raycast (transform.position, upLookPos, SightRange)) 
		{
			Debug.Log ("Player in sight!");
		}
		if (Physics2D.Raycast (transform.position, straightLookPos, SightRange)) 
		{
			Debug.Log ("Player in sight!");
		}
	}
}
