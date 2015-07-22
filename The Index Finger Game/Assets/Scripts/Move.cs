using UnityEngine;
using System.Collections;

public class Move : MouseButton {
	
	Vector2 velocity = Vector2.zero;
	public Vector2 gravity;
	public Vector2 whoops;
	public float moving;
	public Vector2 movinghoriz;
	bool jump = false;
	bool moveleft = false;
	bool moveright = false;
	public float maxspeed = 3f;
	public static float deathcooldown;
	public static bool dead = false;
	public static int death = 0;
	public float jumpHeight;
	public float movespeed;
	public bool isJumping = false;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		dead = false;
		anim = gameObject.GetComponent<Animator>();


	}
	public void Update()
	{
		anim.SetBool ("isJumping", isJumping);
		anim.SetFloat ("Movespeed", moving);
		
		if (dead)
		{
			death = 1;
//			deathcooldown -= Time.deltaTime;
			
//			if(deathcooldown <= 0)
//			{
//				if(Input.GetMouseButtonDown(1))
//				{
//					Application.LoadLevel(Application.loadedLevel);
//				}
				
//			}
		}
		
		
		if (MouseButton.hypataan == 1) 
		{
			jump = true;
		}
		if (MouseButton.hypataan == 0) 
		{
			jump = false;
		}
		if (MouseButton.vasen == 1) 
		{
			moveleft = true;
			transform.localScale = new Vector2(-1, 1);
		}
		if (MouseButton.oikea == 1) 
		{
			moveright = true;
			transform.localScale = new Vector2(1, 1);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(dead)
			return;

		if (jump == true) {
			if(isJumping == false)
			{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}
		}
			
		if (moveleft == true) 
		{
			moveleft = false;
			GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * movespeed);
			moving = 1;


		} 
		else 
		{
			moving = 0;
		}
		if (moveright == true) 
		{
			moveright = false;
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * movespeed);
			moving = 1;
		} 

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			isJumping = false;
		}

	}
}