using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Controls all of the main game logic, including managing
 * player deaths and restarting the game.
 */
public class gamecontroller : MonoBehaviour {
	public GameObject game_over_screen;     /**< A reference to the game over screen UI canvas. */
	public GameObject mobile_input_screen;  /**< A reference to the UI canvas that contains the mobile input. */
	public Button jump_button;              /**< A reference to the UI button for mobile input. */
	public GameObject player_prefab;        /**< The player prefab to be instantiated. */

	public TMP_Text high_score_text;        /**< A reference to the text object containing the high score on the game over screen */

	public camera cam;                      /**< A reference to the camera */
	public level l;                         /**< A reference to the level */

	void Start() {
		on_restart();
	}

	/**
	 * To be called by the "Restart" button on the game over screen.
	 *
	 * Resets the game for another round. This is cleaner than simply
	 * reloading the scene.
	 **/
	public void on_restart() {
		game_over_screen.SetActive(false);

		/* The mobile input should only be enabled on mobile
		 * platforms. It is also enabled in the editor for testing. */
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR
		mobile_input_screen.SetActive(true);
#else 
		mobile_input_screen.SetActive(false);
#endif

		var po = Instantiate(player_prefab, Vector3.zero, Quaternion.identity);
		var p = po.GetComponent<player>();
		p.controller = this;
		p.l = l;

		jump_button.onClick.AddListener(p.jump);

		l.p = p;
		l.on_restart();

		cam.p = p;
	}

	/**
	 * To be called when the player dies. Sets the high score if necessary and
	 * shows the game over screen.
	 */
	public void on_player_die(player p) {
		if (l.score > PlayerPrefs.GetInt("high score")) {
			PlayerPrefs.SetInt("high score", l.score);
		}

		high_score_text.text = "High Score: " + PlayerPrefs.GetInt("high score").ToString();

		game_over_screen.SetActive(true);
		mobile_input_screen.SetActive(false);
	}
}
