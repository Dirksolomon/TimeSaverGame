using UnityEngine;
using System.Collections;

public class TimeMachine : MonoBehaviour {

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
