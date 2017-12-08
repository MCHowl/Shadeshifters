using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject projectile;
	private Transform projectileSpawn;

	private Rigidbody2D rb2d;
	private BoxCollider2D boxCollider;

	public KeyCode UP;
	public KeyCode LEFT;
	public KeyCode RIGHT;
	public KeyCode SHIFT;
	public KeyCode TRIGGER;

	public Sprite sprite_dark;
	public Sprite sprite_light;
	private SpriteRenderer spriteRenderer;

	private int direction = 1; // -1 is left, 1 is right

	private float health = 100;
	private float resource_dark;
	private float speed = 250;

	private int trigger = 0;
	private int trigger_max = 1;

	[HideInInspector]
	public bool dark = false;


	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		projectileSpawn = GetComponentInChildren<Transform>();
	}
		
	void FixedUpdate() {
		if (Input.GetKeyDown(UP)) {
			rb2d.AddForce(new Vector2 (0, 1) * speed);
		} else if (Input.GetKeyDown(LEFT)) {
			rb2d.AddForce(new Vector2 (-1, 0) * speed);
			direction = -1;
		} else if (Input.GetKeyDown(RIGHT)) {
			rb2d.AddForce(new Vector2 (1, 0) * speed);
			direction = 1;
		} else if (Input.GetKeyDown(SHIFT)) {
			trigger++;
			if (trigger > trigger_max) {
				trigger = 0;
			}
		} else if (Input.GetKeyDown(TRIGGER)) {
			if (trigger == 0) {
				dark = !dark;
				if (dark) {
					spriteRenderer.sprite = sprite_dark;
				} else {
					spriteRenderer.sprite = sprite_light;
				}
			} else if (trigger == 1) {
				Vector3 newDirection = new Vector3(direction, 0, 0);

				GameObject newProjectile = Instantiate(projectile, projectileSpawn.position + newDirection, Quaternion.identity);
				newProjectile.GetComponent<ProjectileController>().SetVariables(dark, newDirection);
			}
		}
	}
}