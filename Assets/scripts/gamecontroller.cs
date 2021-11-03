using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamecontroller : MonoBehaviour {
	public GameObject game_over_screen;
	public GameObject player_prefab;
	public GameObject mobile_input_screen;
	public Button jump_button;

	public TMP_Text high_score_text;

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
		if (l.score > PlayerPrefs.GetInt("high score")) {
			PlayerPrefs.SetInt("high score", l.score);
		}

		high_score_text.text = "High Score: " + PlayerPrefs.GetInt("high score").ToString();

		game_over_screen.SetActive(true);
		mobile_input_screen.SetActive(false);
	}
}
