using UnityEngine;
using System.Collections;
//IGNORE BACKUP FILE RANDOM***********************************************************************************************************************
public class Liikebackup : MouseButton {
	
	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 hups;
	public Vector3 liikkuu;
	public Vector3 liikkuuhoriz;
	bool hyppy = false;
	bool liikuvasen = false;
	bool liikuoikea = false;
	public float maksiminopeus = 3f;
	public static float deathcooldown;
	public static bool dead = false;
	
	// Use this for initialization
	void Start () {
		
	}
	public void Update()
	{
		
		if (dead)
		{
			deathcooldown -= Time.deltaTime;
			
			if(deathcooldown <= 0)
			{
				if(Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				
			}
		}
		
		
		if (MouseButton.hypataan == 1) 
		{
			hyppy = true;
		}
		if (MouseButton.hypataan == 0) 
		{
			hyppy = false;
		}
		if (MouseButton.vasen == 1) 
		{
			liikuvasen = true;		
		}
		if (MouseButton.oikea == 1) 
		{
			liikuoikea = true;		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(dead)
			return;
		
		velocity += gravity * Time.deltaTime;
		velocity += liikkuu * Time.deltaTime;
		if (hyppy == true) {
			velocity.y += hups.y;
		}
		if (hyppy = false) {
			velocity.y -= hups.y;
			velocity.x += 5f;
			
		}
		if (liikuvasen == true) {
			liikuvasen = false;
			velocity.z += liikkuuhoriz.z;
		}
		if (liikuoikea == true) {
			liikuoikea = false;
			velocity.z -= liikkuuhoriz.z;
		}
		velocity = Vector3.ClampMagnitude (velocity, maksiminopeus);
		
		transform.position += velocity * Time.deltaTime;
	}
}
