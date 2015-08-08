using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	private AudioSource[] sound;
	private AudioSource run;
	private AudioSource shoot;
	// Use this for initialization
	void Start () 
	{	

	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	//This is audio script for animation sounds.
	void Running()
	{
		sound = gameObject.GetComponents<AudioSource> ();

		run = sound [1];
		run.Play ();
	}
	void Attacking()
	{
		sound = gameObject.GetComponents<AudioSource> ();
		shoot = sound [0];
		shoot.Play ();
	}
}
