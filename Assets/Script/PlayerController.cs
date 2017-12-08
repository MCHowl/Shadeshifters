using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private BoxCollider2D boxCollider;

	public KeyCode UP;
	public KeyCode LEFT;
	public KeyCode RIGHT;
	public KeyCode SHIFT;
	public KeyCode TRIGGER;

	private int trigger = 0;
	private int trigger_max = 1;

	private float health = 100;
	private float resource_dark;
	private float speed = 100;


	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
	}

	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(UP)) {
			rb2d.AddForce(new Vector2 (0, 1) * speed);
		} else if (Input.GetKeyDown(LEFT)) {
			rb2d.AddForce(new Vector2 (-1, 0) * speed);
		} else if (Input.GetKeyDown(RIGHT)) {
			rb2d.AddForce(new Vector2 (1, 0) * speed);
		} else if (Input.GetKeyDown(SHIFT)) {
			trigger++;
			if (trigger > trigger_max) {
				trigger = 0;
			}
		} else if (Input.GetKeyDown(TRIGGER)) {
			Debug.Log("Trigger " + trigger.ToString());
		}
	}
}