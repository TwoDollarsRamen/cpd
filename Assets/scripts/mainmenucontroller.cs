using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * All this class does is set the high score on the main menu when the game starts up.
 */
public class mainmenucontroller : MonoBehaviour {
	public TMP_Text high_score_text; /**< Reference to the text where to display the high score */

	void Start() {
		high_score_text.text = "High Score: " + PlayerPrefs.GetInt("high score").ToString();
	}
}
