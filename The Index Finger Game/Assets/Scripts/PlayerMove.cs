/*
	Mikko is responsible for editing!

	Movements and collisions.
	Updated 2015-7-28 12:51 by Mikko
*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed; // speed
	public float jump; // jump
	public float maxspeed; // maximum speed
	public bool isJumping; // is now performing jump
	public bool isCrouching; // is now performing crouch

	private Rigidbody2D rb2d;
	private Animator animator;
	public static bool dead=false;
	//public static float deathcooldown;
	private BoxCollider2D b;

	// Actions to perform in the beginning
	void Start(){

		// Makes player not dead and also places few gameobjects into variables
		//dead=false;

		rb2d=gameObject.GetComponent<Rigidbody2D>();
		animator=gameObject.GetComponent<Animator>();
		b=gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update(){

		// Checks if certain animation has to be played with isJumping bool and speed of the character
		animator.SetBool("isJumping",isJumping);
		//animator.SetBool ("isCrouching", isCrouching);
		animator.SetFloat("Movespeed",Mathf.Abs(Input.GetAxis("Horizontal")));

		//animator.SetBool("isCrouching",isCrouching);

		//animator.SetBool("isHiding",isHiding);

		// Turns the player around depending on input
		if(Input.GetAxis("Horizontal")<-0.01f){
			transform.localScale = new Vector2(-1,1);
		}
		if(Input.GetAxis("Horizontal")>0.01f){
			transform.localScale = new Vector2(1,1);
		}

	}
	void FixedUpdate(){
		// Horizontal movement (remove sliding somehow!)
		float h=Input.GetAxis("Horizontal");

		if (isCrouching)
			h *= 0.5f;
		else
			h *= 2f;

		rb2d.AddForce((Vector2.right*speed)*h*20);

		// Jumping (or hiding!)
		if(
			isJumping == false && // do not jump if already jumping
			(
				Input.GetKey(KeyCode.W) || // if user presses W
				Input.GetKey(KeyCode.UpArrow) || // if user presses arrow UP
				Input.GetKey(KeyCode.Space) // if user presses Spacebar
			)
		){
			/*

			// the first action to try is hiding
			if(isHidable){
				isHidden=true;
				print ("Hidden!");
			}
			// if hiding was not done, jump (if there is nothing above)
			else

			*/
			if(!Physics2D.Raycast(transform.position,Vector2.up,0.4f)){
				//rb2d.AddForce(Vector2.up*jump);
				//transform.Translate(Vector2.up*Time.deltaTime*jump*20);

				// jumping from crouching position is higher
				if(isCrouching==true){
					rb2d.velocity = Vector2.up * jump * 1.3f;
					//transform.Translate(Vector2.up*Time.deltaTime*jump*5);
				}

				// usual jump
				else rb2d.velocity = Vector2.up * jump;

				isCrouching = false;
				isJumping = true;
			}
		}

		// Checking some speed so the player does not fly off the screen, limiting it to certain number
		if (rb2d.velocity.x > maxspeed){
			rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxspeed){
			rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
		}

		// Checking if crouching key is pressed
		if(
			Input.GetKey(KeyCode.S) || // if user presses S
			Input.GetKey(KeyCode.DownArrow) || // if user presses arrow DOWN
			Input.GetKey(KeyCode.LeftControl) // if user presses Left Control
		){
			Crouch(); // than character starts crouching
		}

		//Checks if crouching key is not pressed and there is nothing above the character to stand
		if(
			!(
				Input.GetKey(KeyCode.S) ||
				Input.GetKey(KeyCode.DownArrow) ||
				Input.GetKey(KeyCode.LeftControl)
			) &&
			!Physics2D.Raycast(transform.position,Vector2.up,0.4f)
		){
			Stand();
		}
	}


	// Crouching code, makes the boxcollider smaller
	void Crouch(){
		b.size=new Vector2(0.36f,0.3f);
		isCrouching=true;
	}

	// Standing up code, makes the boxcollider normal sized again
	void Stand(){
		b.size=new Vector2(0.36f,0.52f);
		isCrouching=false;
	}

	// Checks if the player bumps into something specific.
	void OnCollisionEnter2D(Collision2D col){

		//print (col.gameObject.layer);
		// we landed
		if (col.gameObject.tag == "Ground"){
			isJumping = false; // top surface of elements is ground
			//print ("landed on the ground");
		}
		/*
		if(col.gameObject.tag!="Ground")
			print ("Player met "+col.gameObject.name);
		*/

		// Enables jumping key and removes animation of jumping when touching ground
		//if(col.gameObject.tag=="Ground" && isJumping==true)

		//Checks if player hits hazard object, killing the character
		if(col.gameObject.tag=="Hazard"){
			dead=true;
			Time.timeScale = 0;
		}

		//Makes movingplatform parent of player if it has tag "MovingPlatform" in it, making player stand on the moving platform
		/*if (col.transform.tag == "MovingPlatform") 
		{
			rb2d.transform.parent = col.transform;
			isJumping = false;
		}*/
	}
}