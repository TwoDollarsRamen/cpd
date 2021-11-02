using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
	public GameObject pipe;
	public player p;

	List<GameObject> pipes = new List<GameObject>();

	void Start() {

	}

	public void on_new_pipe_needed() {
		float hole_pos = Random.Range(-5, 5);

		var ps = pipe.GetComponent<Transform>().localScale;

		/* Upper pipe */
		var new_pipe = Instantiate(pipe, new Vector3(p.transform.position.x + 10, ((ps.y / 2.0f) + 2.0f) + hole_pos, 0), Quaternion.identity);

		pipes.Add(new_pipe);

		/* Lower pipe */
		new_pipe = Instantiate(pipe, new Vector3(p.transform.position.x + 10, -((ps.y / 2.0f) + 2.0f) + hole_pos, 0), Quaternion.identity);

		pipes.Add(new_pipe);

		List<GameObject> to_remove = new List<GameObject>();
		foreach (var c in pipes) {
			if (c.transform.position.x < p.transform.position.x - 10) {
				to_remove.Add(c);
			}
		}

		foreach (var c in to_remove) {
			Destroy(c);
			pipes.Remove(c);
		}
	}

	public void on_restart() {
		foreach (var c in pipes) {
			Destroy(c);
		}

		pipes.Clear();
	}
}
