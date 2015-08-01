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
		platform.transform.position = Vector2.MoveTowards (platform.transform.position, currentposition.position, Time.deltaTime * moveSpeed);

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


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			//Debug.Log ("Works!");
			MakeChild();
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			Debug.Log ("Works!");
			RemoveChild();
		}

	}
	void MakeChild()
	{
		player.transform.parent = platform.transform;
	}
	void RemoveChild()
	{
		player.transform.parent = null;
	}
}
