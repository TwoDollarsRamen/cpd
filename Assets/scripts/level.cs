using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level : MonoBehaviour {
	public GameObject pipe;
	public player p;

	public TMP_Text score_text;

	public int score = 0;

	List<GameObject> pipes = new List<GameObject>();

	void Start() {
	}

	public void Update() {
		score_text.text = score.ToString();
	}

	public void on_new_pipe_needed() {
		score++;

		float hole_pos = Random.Range(-5, 5);

		var ps = pipe.GetComponent<Transform>().localScale;

		/* Upper pipe */
		var new_pipe = Instantiate(pipe, new Vector3(p.transform.position.x + 15, ((ps.y / 2.0f) + 2.0f) + hole_pos, 0), Quaternion.identity);

		pipes.Add(new_pipe);

		/* Lower pipe */
		new_pipe = Instantiate(pipe, new Vector3(p.transform.position.x + 15, -((ps.y / 2.0f) + 2.0f) + hole_pos, 0), Quaternion.identity);

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
		score = 0;

		foreach (var c in pipes) {
			Destroy(c);
		}

		pipes.Clear();
	}
}
