using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private AudioSource projectileSound;
	public GameObject projectile;
	private Transform projectileSpawn;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private float groundRadius = 0.2f;

	private Rigidbody2D rb2d;

	public KeyCode UP;
	public KeyCode LEFT;
	public KeyCode RIGHT;
	public KeyCode SHIFT;
	public KeyCode TRIGGER;

	public Sprite sprite_dark;
	public Sprite sprite_light;
	private SpriteRenderer spriteRenderer;

	private int direction = 1; // -1 is left, 1 is right

	private float resource_cost = 0.1f;
	private float resource_max = 1;
	private float resource_min = 0;
	public float speed = 5;
    public float jumpMultiplier = 300;

	private float nextFire;
	private float nextFire_delay = 0.5f;

	[HideInInspector]
	public bool dark = true;
	public int health = 100;
	public float resource_dark;

	void Start() {
		projectileSound = GetComponent<AudioSource>();
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		projectileSpawn = GetComponentInChildren<Transform>();

		resource_dark = (resource_max + resource_min) / 2;
		nextFire = Time.time;
	}

	void Update() {
		if (grounded && Input.GetKeyDown(UP)) {
			rb2d.AddForce(new Vector2(0, jumpMultiplier));
		}

		if (dark) {
			spriteRenderer.sprite = sprite_dark;
		} else {
			spriteRenderer.sprite = sprite_light;
		}
	}
		
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (health <= 0) {
			Destroy (this.gameObject);
		}
			
        if (Input.GetKey(LEFT)) {
			rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            //rb2d.AddForce(new Vector2(-speed, 0));
            if (direction != -1) {
				direction = -1;
				Flip();
			}
		} else if (Input.GetKey(RIGHT)) {
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            //rb2d.AddForce(new Vector2(speed, 0));
            if (direction != 1) {
				direction = 1;
				Flip();
			}
		}

        if (Input.GetKeyDown(SHIFT)) {
			dark = !dark;
		} else if (Input.GetKeyDown(TRIGGER)) {
			if (Time.time > nextFire) {
				bool canFire = false;

				if (dark && resource_dark > resource_min) {
					resource_dark -= resource_cost;
					canFire = true;
				} else if (!dark && resource_dark < resource_max) {
					resource_dark += resource_cost;
					canFire = true;
				}

				if (canFire) {
					Vector3 newDirection = new Vector3 (direction * 0.5f, 0, 0);
					GameObject newProjectile = Instantiate (projectile, projectileSpawn.position + newDirection, Quaternion.identity);
					newProjectile.GetComponent<ProjectileController> ().SetVariables (dark, newDirection);

					nextFire = Time.time + nextFire_delay;
					projectileSound.Play();
				}
			}
		}
	}

	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void RecieveDamage(int damage) {
		health -= damage;
	}
}