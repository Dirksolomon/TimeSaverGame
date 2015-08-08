using UnityEngine;
using System.Collections;

public class TimeMachine : MonoBehaviour {

	//Script for the timemachine at the very start of the game. Makes it play the audio it has and then get destroyed.

	//Might have been simpler to do this with animator plus audio script perhaps now as I look back at it.

	private int DisappearingTime = 2;
	private AudioSource sound;

	// Use this for initialization
	void Start () 
	{
		sound = gameObject.GetComponent<AudioSource> ();
		sound.Play ();
		Destroy (gameObject, DisappearingTime);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
