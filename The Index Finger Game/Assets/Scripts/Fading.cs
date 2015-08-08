using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {
	//Texture to which the game will fade into (Pure black works wonders)
	public Texture2D FadeoutTexture;
	//Fading speed
	public float fadeSpeed = 0.0f;
	//Order in draw hierarchy
	private int drawDepth = -1000;
	//Alpha value, from 0 to 1
	private float alpha = 1.0f;
	//Direction where it fades into, -1 is in and 1 is out.
	private int fadeDir = -1;

	void OnGUI()
	{
		//Fading in or out the alpha value.
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		//Forces the number between 0 and 1.
		alpha = Mathf.Clamp01 (alpha);

		//Sets the GUI into the texture color
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Sets in value of alpha
		GUI.depth = drawDepth; // Makes it render on top of everyth	ing
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), FadeoutTexture); //Draws texture over the screen area
	}
	// We want this to return something, so float instead of void
	public float BeginFade(int direction)
	{
		//Makes the scene fade in or out
		fadeDir = direction;
		return(fadeSpeed); //To time with the Application.Loadlevel
	}
	//When the scene loads up it fades in
	void OnLevelWasLoaded()
	{
		BeginFade (-1);
	}
}
