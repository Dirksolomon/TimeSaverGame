using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject door;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown("up")) 
		{
			door.SetActive(false);
			Debug.Log ("Works!");
		}
	}
	
}
