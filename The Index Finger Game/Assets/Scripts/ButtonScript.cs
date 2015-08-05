using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject door;
	private bool buttonOff = true;

	// Use this for initialization
	void Start(){}
	
	// Update is called once per frame
	void Update(){}

	// Open or close the door with button "E"
	void OnTriggerStay2D(Collider2D other){
		if(Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.Return))
		{
			if(buttonOff == true)
			{
				buttonOff = false;
			}
			else if(buttonOff == false)
			{
				buttonOff = true;
			}
			//Debug.Log ("Works!");
		}

		if(buttonOff == true && Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.Return))
		{
			OpenDoor.DoorClosed = true;
			OpenDoor.DoorOpen = false;
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if(buttonOff == false && Input.GetKeyDown(KeyCode.E) ||Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.Return))
		{
			OpenDoor.DoorClosed = false;
			OpenDoor.DoorOpen = true;
			this.gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
	}
	
}