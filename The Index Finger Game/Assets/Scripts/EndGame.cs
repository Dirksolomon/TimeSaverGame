using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text MoreFuel;

	IEnumerator NeedFuel()
	{
		MoreFuel.text = "You still need more fuel!";
		yield return new WaitForSeconds(1.5f);
		MoreFuel.text = "";
	}

	IEnumerator EndTheGame()
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevel + 1);
	}


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
