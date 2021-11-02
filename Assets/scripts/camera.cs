using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public player p;

	void Update() {
		if (p != null) {
			transform.position = new Vector3(p.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
		}
	}
}
