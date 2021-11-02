using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour {
	public GameObject game_over_screen;
	public GameObject player_prefab;
	public GameObject mobile_input_screen;
	public Button jump_button;

	public camera cam;
	public level l;

	void Start() {
		on_restart();
	}

	public void on_restart() {
		game_over_screen.SetActive(false);

		/* The mobile input should only be enabled on mobile
		 * platforms. It is also enabled in the editor for testing. */
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR
		mobile_input_screen.SetActive(true);
#else 
		mobile_input_screen.SetActive(false);
#endif

		var po = Instantiate(player_prefab);
		var p = po.GetComponent<player>();
		p.controller = this;
		p.l = l;

		jump_button.onClick.AddListener(p.jump);

		l.p = p;
		l.on_restart();

		cam.p = p;
	}

	public void on_player_die(player p) {
		game_over_screen.SetActive(true);
		mobile_input_screen.SetActive(false);
	}
}
