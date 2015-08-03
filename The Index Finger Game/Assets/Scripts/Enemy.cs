using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform upLook;
	public Transform straightLook;
	public Transform downLook;
	public Transform Player;
	private bool PlayerInSight = false;
	private float SightRange = 2f;
//	private Vector2 prevlog = Vector2.zero;
	public GameObject Gun;

	public GameObject Guard;
	
	public float setSpeed;
	private float moveSpeed;
	
	public Transform currentposition;
	
	public Transform[] points;
	
	public int pointSelection;

	public bool facingLeft;

	public GameObject ammo;

	
	// Use this for initialization
	void Start () 
	{
		currentposition = points [pointSelection];
		moveSpeed = setSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		IcanSeeYou ();



		Guard.transform.position = Vector2.MoveTowards (Guard.transform.position, currentposition.position, Time.deltaTime * moveSpeed);
		
		if (Guard.transform.position == currentposition.position) 
		{
			pointSelection++;
			
			//Checks out lenght of array and if it is at the last point
			if(pointSelection == points.Length)
			{
				pointSelection = 0;
			}
			
			currentposition = points[pointSelection];
			Invoke("WalkDirection", 0f);
		}

	}

	void IcanSeeYou()
	{
		Vector2 LookAtPlayer = (Player.transform.position - transform.position).normalized;
		Vector2 upLookPos = (upLook.transform.position - transform.position).normalized;
		Vector2 straightLookPos = (straightLook.transform.position - transform.position).normalized;
		Vector2 downLookPos = (downLook.transform.position - transform.position).normalized;

		Debug.DrawRay(transform.position, upLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, downLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, straightLookPos * SightRange, Color.red);
		//Player is in view
		if (PlayerInSight == true){
			//Cheap placeholder kill.
			Gun.SetActive(true);
			//PlayerMove.dead = true;
			moveSpeed = 0;
			Debug.DrawRay (transform.position, LookAtPlayer * SightRange, Color.green);
			//PlayerCharacter.dead = true;

		} 
		else 
		{
			if(setSpeed != 0)
				moveSpeed = 1;
			Gun.SetActive (false);
		}


		//Checks if player will be hitting the raycasts and then sets true to fact that player is in view of the enemy
		if (Physics2D.Raycast (transform.position, downLookPos, SightRange) || Physics2D.Raycast (transform.position, upLookPos, SightRange) || Physics2D.Raycast (transform.position, straightLookPos, SightRange)) 
		{
			PlayerInSight = true;
			//Debug.Log ("Player in sight!");
		} 
		else
			PlayerInSight = false;
	}

	void WalkDirection()
	{
		facingLeft = !facingLeft;

		if(facingLeft == true)
			transform.localScale = new Vector2(-0.3f,0.3f);
		else
			transform.localScale = new Vector2(0.3f,0.3f);
	}
}
