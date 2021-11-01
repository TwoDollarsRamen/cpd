using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
	Rigidbody rb;

	public float speed = 350;
	public float jump_force = 300;
	public level l;

	float timer = 0.0f;

	void Start() {
		rb = GetComponent<Rigidbody>();

		rb.AddForce(new Vector3(speed, 0, 0));
	}

	void FixedUpdate() {
		if (Input.GetKeyDown("space")) {
			rb.velocity = new Vector3(rb.velocity.x, 0, 0);
			rb.AddForce(new Vector3(0, jump_force, 0));
		}


		/* The timer makes sure the pipes aren't spawned continously. */
		timer += Time.deltaTime;
		if (transform.position.x > 10 && (int)transform.position.x % 10 == 0 && timer > 0.3f) {
			l.on_new_pipe_needed();
			timer = 0.0f;
		}
	}
}
