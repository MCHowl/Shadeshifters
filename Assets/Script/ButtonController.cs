using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
	public void ReloadScene() {
		SceneManager.LoadScene ("Main");
	}

	public void LoadMenu() {
		SceneManager.LoadScene ("Menu");
	}
}
