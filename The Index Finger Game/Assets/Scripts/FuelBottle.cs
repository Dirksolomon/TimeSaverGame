using UnityEngine;
using System.Collections;

public class FuelBottle : MonoBehaviour {

	public GameObject FuelRod;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			FuelRod.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
