﻿/*
	Mikko is responsible for editing!

	Movements and collisions.
	Updated 2015-7-22 12:16
*/

using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

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
		dead=false;

		rb2d=gameObject.GetComponent<Rigidbody2D>();
		animator=gameObject.GetComponent<Animator>();
		b=gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update(){

		//If player dies it blows up the player object
		if(dead){
			gameObject.SetActive(false);
			//deathcooldown -= Time.deltaTime;
			//if(deathcooldown <= 0)
			//{
			//	if(Input.GetMouseButtonDown(0))
			//	{
			//		Application.LoadLevel(Application.loadedLevel);
			//	}
				
			//}
		}
		// Checks if certain animation has to be played with isJumping bool and speed of the character
		animator.SetBool("isJumping",isJumping);
		//animator.SetBool ("isCrouching", isCrouching);
		animator.SetFloat("Movespeed",Mathf.Abs(Input.GetAxis("Horizontal")));

		// Turns the player around depending on input
		if(Input.GetAxis("Horizontal")<-0.01f){
			transform.localScale = new Vector2(-1,1);
		}
		if(Input.GetAxis ("Horizontal")>0.01f){
			transform.localScale = new Vector2(1,1);
		}

	}
	void FixedUpdate()
	{
		// Horizontal movement
		float h = Input.GetAxis ("Horizontal");
		
		rb2d.AddForce ((Vector2.right * speed) * h * 20);
		//rb2d.velocity=Vector2.right*h*speed;
		//rb2d.velocity = Vector2.up * 0;
		
		/*
			if (h<0)
				transform.Translate(-Vector2.right*Time.deltaTime*speed);
			else if(h>0)
				transform.Translate(Vector2.right*Time.deltaTime*speed);
			*/

		// Jumping
		if (
			isJumping == false && // do not jump if already jumping
			(
				Input.GetKey (KeyCode.W) || // if user presses W
				Input.GetKey (KeyCode.UpArrow) || // if user presses arrow UP
				Input.GetKey (KeyCode.Space) // if user presses Spacebar
			)
		) {

			//rb2d.AddForce(Vector2.up*jump);


			//transform.Translate(Vector2.up*Time.deltaTime*jump*20);
			if (isCrouching == true) {

				rb2d.velocity = Vector2.up * jump * 1.3f;
				//transform.Translate(Vector2.up*Time.deltaTime*jump*5);
			} else
				rb2d.velocity = Vector2.up * jump;
			isCrouching = false;
			isJumping = true;
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
			!Physics2D.Raycast(transform.position,Vector2.up,0.4f))
		{
			Stand();
		}
	}


	// Crouching code, makes the boxcollider smaller
	void Crouch(){
		b.size=new Vector2(0.44f,0.3f);
		isCrouching=true;
	}

	// Standing up code, makes the boxcollider normal sized again
	void Stand(){
			b.size=new Vector2(0.44f,0.6f);
	}

	// Checks if the player bumps into something specific.
	void OnCollisionEnter2D(Collision2D col)
	{
		isJumping=false;
		if(col.gameObject.tag!="Ground")
			print ("Player met "+col.gameObject.name);

		// Enables jumping key and removes animation of jumping when touching ground
		//if(col.gameObject.tag=="Ground" && isJumping==true)

		//Checks if player hits hazard object, killing the character
		if(col.gameObject.tag=="Hazard"){
			dead=true;
		}
	}
}
