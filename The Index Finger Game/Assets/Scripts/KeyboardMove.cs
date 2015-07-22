using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

	public float speed = 50f;
	public float jump = 150;
	public float maxspeed = 3;
	public bool isJumping = false;
	public bool isCrouching = false;

	private Rigidbody2D rb2d;
	private Animator animator;
	public static bool dead = false;
	public static float deathcooldown;
	private BoxCollider2D b;


	void Start () 
	{
		//Makes player not dead and also places few gameobjects into variables
		dead = false;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();
		b = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If player dies it blows up the player object
		if (dead)
		{
			Destroy(gameObject);
			//deathcooldown -= Time.deltaTime;
			//if(deathcooldown <= 0)
			//{
			//	if(Input.GetMouseButtonDown(0))
			//	{
			//		Application.LoadLevel(Application.loadedLevel);
			//	}
				
			//}
		}
		//Checks if certain animation has to be played with isJumping bool and speed of the character
		animator.SetBool ("isJumping", isJumping);
		//animator.SetBool ("isCrouching", isCrouching);
		animator.SetFloat ("Movespeed", Mathf.Abs(Input.GetAxis("Horizontal")));
		//Turns the player around depending on input
		if (Input.GetAxis ("Horizontal") < -0.01f) 
		{
			transform.localScale = new Vector2(-1, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.01f) 
		{
			transform.localScale = new Vector2(1, 1);
		}

	}
	void FixedUpdate()
	{
		//Movement
		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce ((Vector2.right * speed) * h);
		if (isJumping == false) {
						if (Input.GetKey (KeyCode.X) && isJumping == false) {
								rb2d.AddForce (Vector2.up * jump);
								isJumping = true;
						}
				}

		// Checking some speed so the player does not fly off the screen, limiting it to certain number
		if (rb2d.velocity.x > maxspeed) 
		{
			rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxspeed) 
		{
			rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
		}
		//Checks if Z is pressed down to crouch
		if (Input.GetKey (KeyCode.Z)) {
			Crouch();
		}
		//Checks if Z is not pressed and there is nothing above the character to stand
		if (!Input.GetKey(KeyCode.Z) && !Physics2D.Raycast (transform.position, Vector2.up, 0.4f))
		{
			Stand();
		}
	}
	//Crouching code, makes the boxcollider smaller
	void Crouch()
	{
		b.size = new Vector2(0.44f, 0.3f);
		//isCrouching = true;
	}
	//Standing up code, makes the boxcollider normal sized again
	void Stand()
	{
			b.size = new Vector2 (0.44f, 0.6f);
	}
	//Checks if the player bumps into something specific.
	void OnCollisionEnter2D(Collision2D col)
	{
		//Enables jumping key and removes animation of jumping when touching ground
		if (col.gameObject.tag == "Ground") 
		{
			isJumping = false;
		}
		//Checks if player hits hazard object, killing the character
		if (col.gameObject.tag == "Hazard") 
		{
			dead = true;
		}
	}
}
