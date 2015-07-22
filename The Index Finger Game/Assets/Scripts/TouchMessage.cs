using UnityEngine;
using System.Collections;

public class TouchMessage : TouchLogic {

	public static int jump = 0;
	public static int left = 0;
	public static int right = 0;

	void NappiPainettu()
	{
		if (this.name == "Jump") 
		{
			jump = 1;
		}
		if (this.name == "Left Button") 
		{
			left = 1;
		}
		if (this.name == "Right Button") 
		{
			right = 1;
		}
		
	}
	void ButtonNotPressed()
	{
		jump = 0;
		left = 0;
		right = 0;
		
	}
}
