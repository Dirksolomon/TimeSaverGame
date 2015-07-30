using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject door;

	// Use this for initialization
	void Start(){}
	
	// Update is called once per frame
	void Update(){}

	// Open or close the door with button "E"
	void OnTriggerStay2D(Collider2D other){
		if(Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Return)){
			if(door.activeSelf)
				door.SetActive(false);
			else door.SetActive(true);
			//Debug.Log ("Works!");
		}
	}
	
}