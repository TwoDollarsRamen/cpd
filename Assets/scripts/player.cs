using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour {
	Rigidbody rb;

	public float speed = 500;
	public float jump_force = 300;

	void Start() {
		rb = GetComponent<Rigidbody>();

		rb.AddForce(new Vector3(speed, 0, 0));
	}

	void FixedUpdate() {
		if (Input.GetKeyDown("space")) {
			rb.velocity = new Vector3(rb.velocity.x, 0, 0);
			rb.AddForce(new Vector3(0, jump_force, 0));
		}
	}
}
