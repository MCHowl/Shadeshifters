using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	private GameObject menuCanvas;
	private GameObject instructionsCanvas;
	private GameObject creditsCanvas;

	void Start () {
		instructionsCanvas = GameObject.Find ("Instructions Canvas");
		creditsCanvas = GameObject.Find ("Credits Canvas");

		DisableCanvas (instructionsCanvas);
		DisableCanvas (creditsCanvas);
	}
	
	public void DisableCanvas(GameObject canvas) {
		canvas.SetActive(false);
	}

	public void EnableCanvas(GameObject canvas) {
		canvas.SetActive(true);
	}

	public void LoadMain() {
		SceneManager.LoadScene ("Main");
	}

	public void ExitGame() {
		Application.Quit ();
	}


}
