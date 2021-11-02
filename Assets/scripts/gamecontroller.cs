using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour {
	public GameObject game_over_screen;

	public GameObject player_prefab;

	public camera cam;
	public level l;

	void Start() {
		on_restart();
	}

	public void on_restart() {
		game_over_screen.SetActive(false);

		var po = Instantiate(player_prefab);
		var p = po.GetComponent<player>();
		p.controller = this;
		p.l = l;

		l.p = p;
		l.on_restart();

		cam.p = p;
	}

	public void on_player_die(player p) {
		game_over_screen.SetActive(true);
	}
}
