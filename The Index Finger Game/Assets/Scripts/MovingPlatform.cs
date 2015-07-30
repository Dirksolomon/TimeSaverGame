using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;

	public Transform currentposition;

	public Transform[] points;

	public int pointSelection;

	// Use this for initialization
	void Start () 
	{
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
}
