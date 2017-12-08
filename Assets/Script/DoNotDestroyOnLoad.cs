using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour {

	private static DoNotDestroyOnLoad instance;

	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (this.gameObject);
		}
	}
}
