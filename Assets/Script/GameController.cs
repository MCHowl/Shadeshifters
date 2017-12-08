using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public Text text_gameOver;

	public Canvas canvas;

	void Start() {
		canvas.enabled = false;
	}
	void Update() {
		if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log (player1 == null);
			Debug.Log (player2 == null);
		}


		if (player1 == null || player2 == null) {
			canvas.enabled = true;
			if (player1 == null) {
				text_gameOver.text = "Player 2 Wins";
			} else {
				text_gameOver.text = "Player 1 Wins";
			}
		}
	}
}
