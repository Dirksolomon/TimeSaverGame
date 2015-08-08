using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//Points which towards the enemy will be raycasting.
	public Transform upLook;
	public Transform straightLook;
	public Transform downLook;
	//Looks where the player is and also a bool to check if it is on sights or not
	private Transform Player;
	private bool PlayerInSight = false;
	//Range of the Raycast
	private float SightRange = 5f;
	//Animator for enemy
	private Animator anim;
	//Gun child
	public GameObject Gun;
	Transform EnemyGun;
	//Bool to see if enemy is dead
	private bool guardisdead = false;
	//The enemy object
	public GameObject Guard;
	//Speeds for moving about
	public float setSpeed;
	private float moveSpeed;

	//Position they are trying to get to
	public Transform currentposition;
	//Points of movement in array
	public Transform[] points;
	public int pointSelection;

	//Checks where the enemy will be facing
	public bool facingLeft;
	//So gun arm can use it
	public static bool isFacingLeft;
	//Spot for the enemys script, aka this one
	private Enemy enemyscript;
	//Enemy objects rigidbody
	private Rigidbody2D rb2d;
	//Audio from the enemy
	private AudioSource death;


	
	// Use this for initialization
	void Start () 
	{
		//Set things into the corresponding variables
		anim = gameObject.GetComponent<Animator> ();
		currentposition = points [pointSelection];
		moveSpeed = setSpeed;
		EnemyGun = transform.FindChild ("NPC1Gun");
		rb2d=gameObject.GetComponent<Rigidbody2D>();
		enemyscript = gameObject.GetComponent<Enemy> ();
		death = gameObject.GetComponent<AudioSource> ();
		Player = GameObject.Find ("Character").transform;
	}
	
	// Update is called once per frame
	void Update () {

		//Throws info to the animator to animate with
		anim.SetFloat("moveSpeed",moveSpeed);
		anim.SetBool ("dead", guardisdead);

		//Checks if the enemy sees player
		IcanSeeYou ();


		//Makes walk towards point with certain movespeed
		Guard.transform.position = Vector2.MoveTowards (Guard.transform.position, currentposition.position, Time.deltaTime * moveSpeed);
		//Checks out where the guard is and changes direction when reaching other point
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
		//Checks where the enemy is facing and sets it into the static bool so it can be used by NPC1Guns AimGun script
		if (facingLeft == true) 
		{
			isFacingLeft = true;
		} 
		else 
		{
			isFacingLeft = false;
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
		/*Debug.DrawRay(transform.position, upLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, downLookPos * SightRange, Color.red);
		Debug.DrawRay(transform.position, straightLookPos * SightRange, Color.red);*/

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
				moveSpeed = setSpeed;

			Gun.SetActive (false);
		}


		//Checks if player will be hitting the raycasts and then sets true to fact that player is in view of the enemy
		if (Physics2D.Raycast (transform.position, downLookPos, SightRange)) 
		{
			RaycastHit2D hit1 = Physics2D.Raycast (transform.position, downLookPos, SightRange);

			if(hit1.collider.tag == "Player")
			{
				PlayerInSight = true;
			}
		}
		else if(Physics2D.Raycast (transform.position, upLookPos, SightRange))
		{
			RaycastHit2D hit2 = Physics2D.Raycast (transform.position, upLookPos, SightRange);
			if(hit2.collider.tag == "Player")
			{
				PlayerInSight = true;
			}

		}
		else if(Physics2D.Raycast (transform.position, straightLookPos, SightRange))
		{
			RaycastHit2D hit3 = Physics2D.Raycast (transform.position, straightLookPos, SightRange);
			if(hit3.collider.tag == "Player")
			{
				PlayerInSight = true;
			}
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
			isFacingLeft = true;
			transform.localScale = new Vector2 (-1f, 1f);
			EnemyGun.localScale = new Vector2(1f, 1f);
		} 
		else 
		{
			isFacingLeft = false;
			transform.localScale = new Vector2 (1f, 1f);
			EnemyGun.localScale = new Vector2(-1f, -1f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Checks if player hits it with the collider kill object and murders the enemy if so.
		if (coll.gameObject.tag == "EnemyKill")
		{

			StartCoroutine(WaitABit());
		}
		
		
	}

	IEnumerator WaitABit()
	{
		//Kills the guards script with slight delay so animation and death sound have time to trigger and play out.
		guardisdead = true;
		death.Play ();
		yield return new WaitForSeconds(0.1f);
		enemyscript.enabled = false;
		//Launches the enemy off a bit when they die
		rb2d.AddForce(Vector2.up * 10);
		rb2d.AddForce(Vector2.right * 10);
	}
}
