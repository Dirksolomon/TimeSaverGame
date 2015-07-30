using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject enemyGuard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemyGuard.transform.Translate(Vector2.right*2);
		enemyGuard.transform.Translate(-Vector2.right*2);
	}
}
