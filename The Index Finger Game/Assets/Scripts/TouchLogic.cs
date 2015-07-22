using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touches.Length <= 0) 
		{
				
						//If screen is not touched this happens
		
		}

		else
		{
			for(int i = 0; i <Input.touchCount; i++)
			{
				if(this.GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position))
				   {

				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					this.SendMessage("ButtonPressed");

				}
				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					this.SendMessage("ButtonNotPressed");
				}

				}

			}

		}

	
	}
}
