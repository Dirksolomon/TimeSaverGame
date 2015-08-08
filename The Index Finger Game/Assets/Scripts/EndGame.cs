using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text MoreFuel;
	//Gives GUI message that the player needs some more fuel before they can finish
	IEnumerator NeedFuel()
	{
		MoreFuel.text = "You still need more fuel!";
		yield return new WaitForSeconds(1.5f);
		MoreFuel.text = "";
	}
	//Ends the game with fade
	IEnumerator EndTheGame()
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	//Checks out if the player tag hits the trigger and has 6 fuels collected, allowing the trigger to fire EndTheGame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && NewPlayerMove.fuelcollected == 6) 
		{
			StartCoroutine(EndTheGame());
		} 
		else 
		{
			StartCoroutine(NeedFuel());
		}
	}
}
