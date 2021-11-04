using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Controls any menu that needs to load scenes or quit the game.
 */
public class menucontroller : MonoBehaviour {
	/**
	 * Loads a scene. The scene name doesn't need the .unity extension.
	 */
	public void load_scene(string name) {
		SceneManager.LoadScene(name);
	}

	/**
	 * Quits the game, or stops the game from playing if running in the editor.
	 */
	public void quit_game() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
