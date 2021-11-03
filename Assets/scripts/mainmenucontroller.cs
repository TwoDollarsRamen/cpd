using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainmenucontroller : MonoBehaviour {
	public TMP_Text high_score_text;

	void Start() {
		high_score_text.text = "High Score: " + PlayerPrefs.GetInt("high score").ToString();
	}
}
