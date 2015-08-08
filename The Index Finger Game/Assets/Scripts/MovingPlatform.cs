using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;

	public Transform currentposition;

	public Transform[] points;

	public int pointSelection;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Character");
		currentposition = points [pointSelection];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Makes platform to move towards certain point
		platform.transform.position = Vector2.MoveTowards (platform.transform.position, currentposition.position, Time.deltaTime * moveSpeed);

		//Checks if the platform reaches certain point, sets new point to go until there are no points and it just goes back to first
		if (platform.transform.position == currentposition.position) 
		{
			pointSelection++;

			//Checks out lenght of array and if it is at the last point
			if(pointSelection == points.Length)
			{
				pointSelection = 0;
			}

			currentposition = points[pointSelection];
		}

	}
	//When players collider bumps into this ones, sets player as child object
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			//Debug.Log ("Works!");
			MakeChild();
		}
	}
	//If players collider does not bump against this one it removes player as child object
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			//Debug.Log ("Works!");
			RemoveChild();
		}

	}
	//Makes player the child of the object so it travels with it
	void MakeChild()
	{
		player.transform.parent = platform.transform;
	}
	//Removes the player as child object
	void RemoveChild()
	{
		player.transform.parent = null;
	}
}
