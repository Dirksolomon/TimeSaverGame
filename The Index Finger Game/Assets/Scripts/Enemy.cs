using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform upLook;
	public Transform straightLook;
	public Transform downLook;
	public Transform Player;
	private bool PlayerInSight = false;
	private float SightRange = 5f;
	public GameObject Gun;
	Transform EnemyGun;

	public GameObject Guard;
	
	public float setSpeed;
	private float moveSpeed;
	
	public Transform currentposition;
	
	public Transform[] points;
	
	public int pointSelection;

	public bool facingLeft;

	public static bool isFacingLeft;
	private Enemy enemyscript;
	private Rigidbody2D rb2d;


	
	// Use this for initialization
	void Start () 
	{
		currentposition = points [pointSelection];
		moveSpeed = setSpeed;
		EnemyGun = transform.FindChild ("NPC1Gun");
		rb2d=gameObject.GetComponent<Rigidbody2D>();
		enemyscript = gameObject.GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Checks if the enemy sees player
		IcanSeeYou ();
		//Sets where enemy is facing on the static bool
		if (facingLeft == true)
			isFacingLeft = true;
		else if (facingLeft == false)
			isFacingLeft = false;


		//Makes walk towards point with certain movespeed
		Guard.transform.position = Vector2.MoveTowards (Guard.transform.position, currentposition.position, Time.deltaTime * moveSpeed);
		//Checks out where the guard is and changes direction when reaching other point
		if (Guard.transform.position == currentposition.position) 
		{
			Debug.Log("GuardHere");
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
		//Follows player
		Vector2 LookAtPlayer = (Player.transform.position - transform.position).normalized;
		//Points where the enemy is looking at
		Vector2 upLookPos = (upLook.transform.position - transform.position).normalized;
		Vector2 straightLookPos = (straightLook.transform.position - transform.position).normalized;
		Vector2 downLookPos = (downLook.transform.position - transform.position).normalized;
		//To debug the sight
		Debug.DrawRay(transform.position, upLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, downLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, straightLookPos * SightRange, Color.red);
		//Player is in view, activates the gun hand and also stops
		if (PlayerInSight == true){
			Gun.SetActive(true);
			moveSpeed = 0;
			Debug.DrawRay (transform.position, LookAtPlayer * SightRange, Color.green);

		} 
		//If player is not in sight hides the gun and continues moving
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
		//Checks out where the enemy is facing and adjusts it accordingly.
		facingLeft = !facingLeft;

		if (facingLeft == true) 
		{
			transform.localScale = new Vector2 (-1f, 1f);
			EnemyGun.localScale = new Vector2(1f, 1f);
		} 
		else 
		{
			transform.localScale = new Vector2 (1f, 1f);
			EnemyGun.localScale = new Vector2(-1f, -1f);
		}
	}
	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Hit");
			enemyscript.enabled = false;
			rb2d.constraints = RigidbodyConstraints2D.None;
			rb2d.AddForce(Vector2.up * 300);
			rb2d.AddForce(Vector2.right * 300);
			//rb2d.rotation

		}
		
		
	}
}
