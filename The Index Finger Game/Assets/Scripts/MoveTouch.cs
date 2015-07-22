using UnityEngine;
using System.Collections;

public class MoveTouch : TouchMessage {
	
	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 hups;
	public Vector3 moving;
	public Vector3 movinghoriz;
	bool jump = false;
	bool moveleft = false;
	bool moveright = false;
	public float maxspeed = 5f;
	
	
	// Use this for initialization
	void Start () {
		
	}
	public void Update()
	{
		if (TouchMessage.jump == 1) 
		{
			jump = true;
		}
		if (TouchMessage.jump == 0) 
		{
			jump = false;
		}
		if (TouchMessage.left == 1) 
		{
			moveleft = true;		
		}
		if (TouchMessage.right == 1) 
		{
			moveright = true;		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity += gravity * Time.deltaTime;
		velocity += moving * Time.deltaTime;
		if (jump == true) 
		{
			velocity.y += hups.y;
		}
		if (jump = false)
		{
			velocity.y -= hups.y;
			velocity.x += 1f;
			
		}
		if (moveleft == true) 
		{
			moveleft = false;
			velocity.z += movinghoriz.z;
		}
		if (moveright == true) 
		{
			moveright = false;
			velocity.z -= movinghoriz.z;
		}
		velocity = Vector3.ClampMagnitude (velocity, maxspeed);
		
		transform.position += velocity * Time.deltaTime;
	}
}