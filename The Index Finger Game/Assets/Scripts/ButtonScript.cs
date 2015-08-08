using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	

	public GameObject door;
	private bool buttonOff = true;
	private Animator anim;
	private bool animatorOff = true;
	private AudioSource[] sound;
	private AudioSource buttonsound;
	private AudioSource doorsound;

	// Use this for initialization
	void Awake()
	{
		//Gets audio and animation into variables, also sets buttons state.
		sound = gameObject.GetComponents<AudioSource> ();
		anim=gameObject.GetComponent<Animator>();
		buttonsound = sound[0];
		doorsound = sound [1];
		buttonOff = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		//Sets bool into variable
		anim.SetBool("buttonOff",animatorOff);
		//Checks if button is off or on and works with doors script animating it.
		if(buttonOff == true)
		{
			animatorOff = true;
			door.GetComponent<OpenDoor>().DoorClosed = true;
			door.GetComponent<OpenDoor>().DoorOpen = false;

		}
		else if(buttonOff == false)
		{
			animatorOff = false;
			door.GetComponent<OpenDoor>().DoorClosed = false;
			door.GetComponent<OpenDoor>().DoorOpen = true;
		}

	}


	void OnTriggerStay2D(Collider2D other)
	{
		// Open or close the door with button "E" while being in the trigger area as player.
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
		}



	}
	
}