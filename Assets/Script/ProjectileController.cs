using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private float destroyTime;
	private float aliveTime = 3;
	private float speed = 15;
	private int damage = 10;

	private Vector3 direction;

	public Sprite sprite_dark;
	public Sprite sprite_light;
	private SpriteRenderer spriteRenderer;

	[HideInInspector]
	public bool dark = false;

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
		if (other.gameObject.CompareTag ("Projectile")) {
			if (other.gameObject.GetComponent<ProjectileController> ().dark != dark) {
				Destroy (this.gameObject);
			}
		} else if (other.gameObject.CompareTag ("Player")) {
			if (other.gameObject.GetComponent<PlayerController> ().dark != dark) {
				other.gameObject.GetComponent<PlayerController> ().RecieveDamage (damage);
				Destroy (this.gameObject);
			}
		} else {
			Destroy (this.gameObject);
		}
	}

	public void SetVariables(bool newDark, Vector3 newDirection) {
		direction += newDirection;
		dark = newDark;

		if (direction.x < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (dark) {
			spriteRenderer.sprite = sprite_dark;
		} else {
			spriteRenderer.sprite = sprite_light;
		}
	}
}
