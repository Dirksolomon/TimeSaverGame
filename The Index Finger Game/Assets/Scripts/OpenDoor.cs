using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public static bool DoorClosed;
	public static bool DoorOpen;
	private Animator animator;
	// Use this for initialization
	void Start () 
	{
		animator=gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(DoorOpen == true)
		{
			animator.SetBool("DoorOpen", DoorOpen);
			animator.SetBool("DoorClosed",DoorClosed);
		}
		if (DoorClosed == true) 
		{
			animator.SetBool("DoorClosed",DoorClosed);
			animator.SetBool("DoorOpen", DoorOpen);
		}
	}
}
