using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class controls the camera.
 * It will snap the y position of the camera to the y position of the player.
 */
public class camera : MonoBehaviour {
	public player p; /**< A reference to the player. */

	/**
	 * Called every frame by Unity. Snaps the y position of the camera to
	 * the y position of the player.
	 */
	void Update() {
		if (p != null) {
			transform.position = new Vector3(p.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
		}
	}
}
