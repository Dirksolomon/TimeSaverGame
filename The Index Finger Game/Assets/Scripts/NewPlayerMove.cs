using UnityEngine;
using System.Collections;

public class NewPlayerMove : MonoBehaviour {
		
		public float speed; // speed
		public float jump; // jump
		public float maxspeed; // maximum speed
		public bool isJumping; // is now performing jump
		public bool isCrouching; // is now performing crouch
		public bool isAttacking;
		public bool isClinging;
		public bool isFalling;
		private Rigidbody2D rb2d;
		private Animator animator;
		public static bool dead=false;
		//public static float deathcooldown;
		private BoxCollider2D b;
		public GameObject attack;

		public static int fuelcollected;
		
		// Actions to perform in the beginning
		void Start()
		{
			rb2d=gameObject.GetComponent<Rigidbody2D>();
			animator=gameObject.GetComponent<Animator>();
			b=gameObject.GetComponent<BoxCollider2D>();
			//On load sets fuel amount to 0.
			fuelcollected = 0;
		}
		
		// Update is called once per frame
		void Update()
		{
			//Pushes the updates into the animator
			Animation ();
			// Turns the player around depending on input
			TurnAround ();


		// Jumping (or hiding!)
		if (isJumping == false // do not jump if already jumping
			&& (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space))) { //Checks what key is pressed for jumping

			if(!Physics2D.Raycast(transform.position,Vector2.up,2f))
			{
				
				// high jump
				if(isCrouching==true)
				{
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
		void FixedUpdate()
		{


		
		float h=Input.GetAxis("Horizontal");
		
		// moving slower when crouching
		if (isCrouching)
			h *= 0.5f;
		
		rb2d.AddForce((Vector2.right*speed)*h*40);
		
		
		
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
		if(!(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) 
		   && !Physics2D.Raycast(transform.position,Vector2.up,2f))
		{
			Stand();
		}
		
		//Attack
		if (Input.GetKey ("left shift") || Input.GetKey ("right shift")) 
		{
			attack.SetActive(true);
			isAttacking = true;
		} 
		else 
		{
			attack.SetActive(false);
			isAttacking = false;
		}
	}
	
	
	// Crouching code, makes the boxcollider smaller
		void Crouch()
		{
			b.size=new Vector2(b.size.x,1.35f);
			isCrouching=true;
		}
		
		// Standing up code, makes the boxcollider normal sized again
		void Stand()
		{
			b.size=new Vector2(b.size.x,2.28f);
			isCrouching=false;
		}
		
		// Checks if the player bumps into something specific.
		void OnCollisionEnter2D(Collision2D col)
		{
			
			// we landed
			if (
				col.gameObject.tag == "Ground" &&
			!Physics2D.Raycast (transform.position, Vector2.up, 0.5f)
				) {
			isJumping = false;
			isClinging = false;
			}
			if (col.gameObject.tag == "Wall") 
			{
				isJumping = false;
				isClinging = true;
			}
			else
				isClinging = false;
			
			//Checks if player hits hazard object, killing the character
			if(col.gameObject.tag=="Hazard")
			{
				//Debug.Log ("Touching");
				dead=true;
			}
			
		}

		//Turns the character around
		void TurnAround()
		{
			if(Input.GetAxis("Horizontal")<-0.01f)
			{
				transform.localScale = new Vector2(1,1);
			}

			if(Input.GetAxis("Horizontal")>0.01f)
			{
				transform.localScale = new Vector2(-1,1);
			}
		}

		//Puts variables into animator which then animates the character
		void Animation()
		{
			animator.SetBool("isJumping",isJumping);
			animator.SetBool ("IsCrouching", isCrouching);
			animator.SetFloat("moveSpeed",Mathf.Abs(Input.GetAxis("Horizontal")));
			animator.SetBool ("isAttacking", isAttacking);
			animator.SetBool ("TouchingWall", isClinging);
			animator.SetBool ("isFalling", isFalling);
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "FuelBottle") 
			{
				fuelcollected++;
				//Debug.Log(fuelcollected);
			}
		}

	}