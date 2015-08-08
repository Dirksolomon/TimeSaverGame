using UnityEngine;
using System.Collections;

public class FuelBottle : MonoBehaviour {

	public GameObject FuelRod;


	//If player collides with its trigger, it gets removed
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			FuelRod.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
