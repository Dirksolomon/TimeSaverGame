using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform Player;

	public Vector2 marg, smooth;

	public BoxCollider2D Bounds;

	private Vector3 _min, _max;

	public bool Following {get; set;}

	// Use this for initialization
	void Start () 
	{
		//Sets variables for max and min bounds which camera cannot follow past and sets following bool to true so it follows
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		Following = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Starts by checking if player is dead or not
		if (KeyboardMove.dead == false) {
		
			var x = transform.position.x;
			var y = transform.position.y;

			if (Following) {
				if (Mathf.Abs (x - Player.position.x) > marg.x)
					x = Mathf.Lerp (x, Player.position.x, smooth.x * Time.deltaTime);

				if (Mathf.Abs (y - Player.position.y) > marg.y)
					y = Mathf.Lerp (y, Player.position.y, smooth.y * Time.deltaTime);

			}

			var cameraWidth = GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);

			x = Mathf.Clamp (x, _min.x + cameraWidth, _max.x - cameraWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera> ().orthographicSize, _max.y - GetComponent<Camera> ().orthographicSize);

			transform.position = new Vector3 (x, y, transform.position.z);
		}
	}
}
