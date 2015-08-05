/**
	Autor: Mikhail Timofeev
	Updated: 2.8.2015
*/
using UnityEngine;
using System.Collections;

public class NewPlayerMoveForBiggerSpriteBONETEST : MonoBehaviour {

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
	private Transform Nathan;
	private GameObject NathanGameObject;
	private GameObject NathanCrawlObject;
	private GameObject NathanJumping;

	// Actions to perform in the beginning
	void Start(){

		// Makes player not dead and also places few gameobjects into variables
		//dead=false;

		rb2d=gameObject.GetComponent<Rigidbody2D>();
		animator=GetComponentInChildren<Animator>();
		b=gameObject.GetComponent<BoxCollider2D>();
		NathanGameObject = GameObject.Find ("Nathan");
		NathanCrawlObject = GameObject.Find("CrawlNathan");
		NathanJumping = GameObject.Find ("jump");

		Nathan = transform.FindChild ("Nathan");
	}
	
	// Update is called once per frame
	void Update(){
		Debug.DrawRay(Nathan.position,Vector2.up*2, Color.red);

		// ANIMATION START**
		if (isJumping == true) 
		{
			NathanGameObject.SetActive(false);
			NathanJumping.SetActive(true);
		} 
		else if (isJumping == false)
		{
			NathanGameObject.SetActive(true);
			NathanJumping.SetActive(false);
		}

		animator.SetFloat("Movespeed",Mathf.Abs(Input.GetAxis("Horizontal")));

		if (isCrouching == true) 
		{
			NathanGameObject.SetActive(false);
			NathanCrawlObject.SetActive(true);
			//animator.SetBool ("isCrouching", isCrouching);
		} 
		else if (isCrouching == false && isJumping == false)
		{
			NathanGameObject.SetActive(true);
			NathanCrawlObject.SetActive(false);
		}

		//animator.SetBool("isHiding",isHiding);

		// ANIMATION END**

		// TURNS THE PLAYER AROUND DEPENDING ON INPUT
		TurnCharacter ();

		// Jumping (or hiding!)
		if(
			isJumping == false && // do not jump if already jumping
			(
				Input.GetKeyDown(KeyCode.W) || // if user presses W
				Input.GetKeyDown(KeyCode.UpArrow) || // if user presses arrow UP
				Input.GetKeyDown(KeyCode.Space) // if user presses Spacebar
			)
		){
			if(!Physics2D.Raycast(Nathan.position,Vector2.up,2)){
				
				// high jump
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
	}
	void FixedUpdate(){
		// Horizontal movement (remove sliding somehow!)
		float h=Input.GetAxis("Horizontal");

		// moving slower when crouching
		if (isCrouching)
			h *= 0.5f;

		rb2d.AddForce((Vector2.right*speed)*h*40);
		//print (rb2d.velocity);

		

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
			Input.GetKey(KeyCode.LeftControl) || // if user presses Left Control
			Input.GetKey(KeyCode.RightControl) // if user presses Right Control
		){
			Crouch(); // than character starts crouching
		}

		//Checks if crouching key is not pressed and there is nothing above the character to stand
		if(
			!(
				Input.GetKey(KeyCode.S) ||
				Input.GetKey(KeyCode.DownArrow) ||
				Input.GetKey(KeyCode.LeftControl) ||
				Input.GetKey(KeyCode.RightControl)
			) &&
			!Physics2D.Raycast(Nathan.position,Vector2.up,2)
		){
			Stand();
		}
	}


	// Crouching code, makes the boxcollider smaller
	void Crouch(){
		b.size=new Vector2(1.82f,2.25f);
		isCrouching=true;
	}

	// Standing up code, makes the boxcollider normal sized again
	void Stand(){
		b.size=new Vector2(1.82f,4.54f);
		isCrouching=false;
	}

	// Checks if the player bumps into something specific.
	void OnCollisionEnter2D(Collision2D col){

		// we landed
		if (
			col.gameObject.tag == "Ground" &&
		    !Physics2D.Raycast(Nathan.position,Vector2.up,2)
		){
			isJumping = false;
		}

		//Checks if player hits hazard object, killing the character
		if(col.gameObject.tag=="Hazard"){
			dead=true;
		}

	}
	//TURNS CHARACTER DEPENDING ON INPUT
	void TurnCharacter()
	{
		if(Input.GetAxis("Horizontal")<-0.01f){
			Nathan.localScale = new Vector2(1f,1f);
			NathanCrawlObject.transform.localScale = new Vector2(1f,1f);
			NathanJumping.transform.localScale = new Vector2(1.8f,1.8f);
		}
		if(Input.GetAxis("Horizontal")>0.01f){
			Nathan.localScale = new Vector2(-1f,1f);
			NathanCrawlObject.transform.localScale = new Vector2(-1f,1f);
			NathanJumping.transform.localScale = new Vector2(-1.8f,1.8f);
		}
		
		if(Input.GetAxis("Horizontal")<-0.01f){

		}
		if(Input.GetAxis("Horizontal")>0.01f){

		}

	}
}