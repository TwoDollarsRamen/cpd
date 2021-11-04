using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Responsible for controlling the player.
 */
[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
	Rigidbody rb;

	public float speed = 350;           /**< The sideways force to add to the player on start. */
	public float jump_force = 300;      /**< The upwards force to add to the player every time the jump button is pressed */
	public level l;                     /**< A reference to the level */

	public gamecontroller controller;   /**< A reference to the game controller script in the scene. */

	float timer = 0.0f;

	void Start() {
		rb = GetComponent<Rigidbody>();

		rb.AddForce(new Vector3(speed, 0, 0));
	}

	void Update() {
		if (Input.GetKeyDown("space")) {
			jump();
		}
	}

	void FixedUpdate() {
		/* The timer makes sure the pipes aren't spawned continously. */
		timer += Time.deltaTime;
		if (transform.position.x > 10 && (int)transform.position.x % 10 == 0 && timer > 0.3f) {
			l.on_new_pipe_needed();
			timer = 0.0f;
		}
	}

	void OnCollisionEnter(Collision c) {
		controller.on_player_die(this);

		Destroy(gameObject);
	}

	/**
	 * Cancel any existing movement and add an upwards force accoring to the "speed" member.
	 */
	public void jump() {
		GetComponent<AudioSource>().Play();

		/* Cancel exisiting movement to make the movement
		 * more predictable.*/
		rb.velocity = new Vector3(rb.velocity.x, 0, 0);

		rb.AddForce(new Vector3(0, jump_force, 0));
	}
}
