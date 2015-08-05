using UnityEngine;
using System.Collections;

public class ButtonPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//With action key E, F or Enter the platforms get switched on and off, turning the button either red or green.
	void OnTriggerStay2D(Collider2D other){
		if(
			Input.GetKeyDown(KeyCode.E) ||
			Input.GetKeyDown(KeyCode.F) ||
			Input.GetKeyDown(KeyCode.Return)
			){
			if(MovingPlatform.moveSpeed == 2f)
			{
				MovingPlatform.moveSpeed = 0f;
				this.gameObject.GetComponent<Renderer>().material.color = Color.red;
			}
			else 
			{
				MovingPlatform.moveSpeed = 2f;
				this.gameObject.GetComponent<Renderer>().material.color = Color.green;
			}
			//Debug.Log ("Works!");
		}
	}
}
