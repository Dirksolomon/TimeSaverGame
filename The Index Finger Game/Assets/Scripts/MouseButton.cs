using UnityEngine;
using System.Collections;

public class MouseButton : MonoBehaviour {
public static int hypataan = 0;
public static int vasen = 0;
public static int oikea = 0;
public void OnMouseDown()
	{
		if (this.name == "Hyppy") 
		{
			hypataan = 1;
		}
		if (this.name == "Left Button") 
		{
			vasen = 1;
		}
		if (this.name == "Right Button") 
		{
			oikea = 1;
		}
	}
public void OnMouseUp()
	{
		hypataan = 0;
		vasen = 0;
		oikea = 0;
	}

	public void OnMouseClick()
	{


	}
}
