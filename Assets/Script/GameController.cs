using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	private PlayerController player1Controller;
	private PlayerController player2Controller;

	public Canvas canvas;
	public Text text_gameOver;

	public Sprite Icon_1_Dark;
	public Sprite Icon_1_Light;
	public Image Icon_1;
	public Image Resource_1;
	public Image Health_1;

	public Sprite Icon_2_Dark;
	public Sprite Icon_2_Light;
	public Image Icon_2;
	public Image Resource_2;
	public Image Health_2;

	void Start() {
		canvas.enabled = false;

		player1Controller = player1.GetComponent<PlayerController>();
		player2Controller = player2.GetComponent<PlayerController>();
	}

	void Update() {
		Health_1.fillAmount = player1Controller.health / 100f;
		Resource_1.fillAmount = player1Controller.resource_dark;

		if (player1Controller.dark) {
			Icon_1.sprite = Icon_1_Dark;
		} else {
			Icon_1.sprite = Icon_1_Light;
		}

		Health_2.fillAmount = player2Controller.health / 100f;
		Resource_2.fillAmount = player2Controller.resource_dark;

		if (player2Controller.dark) {
			Icon_2.sprite = Icon_2_Dark;
		} else {
			Icon_2.sprite = Icon_2_Light;
		}	
			
		if (player1 == null || player2 == null) {
			canvas.enabled = true;
			if (player1 == null) {
				text_gameOver.text = "ShiftBot Wins";
			} else {
				text_gameOver.text = "Mr Shifty Wins";
			}
		}
	}
}
