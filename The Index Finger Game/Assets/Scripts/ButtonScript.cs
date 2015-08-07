using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public GameObject door;
	private bool buttonOff = true;
	private Animator anim;
	private bool animatorOff = true;
	private AudioSource[] audio;
	private AudioSource buttonsound;
	private AudioSource doorsound;

	// Use this for initialization
	void Awake()
	{
		audio = gameObject.GetComponents<AudioSource> ();
		anim=gameObject.GetComponent<Animator>();
		buttonsound = audio[0];
		doorsound = audio [1];
		buttonOff = true;

	}
	
	// Update is called once per frame
	void Update()
	{
		anim.SetBool("buttonOff",animatorOff);

		if(buttonOff == true)
		{
			OpenDoor.DoorClosed = true;
			OpenDoor.DoorOpen = false;
			animatorOff = true;
		}
		else if(buttonOff == false)
		{
			OpenDoor.DoorClosed = false;
			OpenDoor.DoorOpen = true;
			animatorOff = false;
		}

	}

	// Open or close the door with button "E"
	void OnTriggerStay2D(Collider2D other){

		if(other.transform.tag == "Player" && Input.GetKeyDown(KeyCode.E) || other.transform.tag == "Player" && Input.GetKeyDown(KeyCode.F) || other.transform.tag == "Player" && Input.GetKeyDown(KeyCode.Return))
		{
			if(buttonOff == true)
			{
				doorsound.Play();
				buttonsound.Play();
				buttonOff = false;
			}
			else if(buttonOff == false)
			{
				doorsound.Play();
				buttonsound.Play();
				buttonOff = true;
			}
			//Debug.Log ("Works!");
		}



	}
	
}