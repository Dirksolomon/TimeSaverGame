using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	private AudioSource[] audio;
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

	void Running()
	{
		audio = gameObject.GetComponents<AudioSource> ();

		run = audio [1];
		run.Play ();
	}
	void Attacking()
	{
		audio = gameObject.GetComponents<AudioSource> ();
		shoot = audio [0];
		shoot.Play ();
	}
}
