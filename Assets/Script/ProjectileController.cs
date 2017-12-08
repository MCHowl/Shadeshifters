using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private float destroyTime;
	private float aliveTime = 5;
	private float speed = 5;

	private Vector3 direction;

	public Sprite sprite_dark;
	public Sprite sprite_light;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		direction = new Vector3(0, 0, 0);
	}

	void Start() {
		destroyTime = Time.time + aliveTime;
	}

	void Update() {
		if (Time.time > destroyTime) {
			Destroy(this.gameObject);
		}
	}

	void FixedUpdate() {
		transform.position += direction * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("hit");
		Destroy(this.gameObject);
	}

	public void SetVariables(bool dark, Vector3 newDirection) {
		direction += newDirection;

		if (dark) {
			spriteRenderer.sprite = sprite_dark;
		} else {
			spriteRenderer.sprite = sprite_light;
		}
	}
}
