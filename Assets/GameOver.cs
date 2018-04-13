using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	private Data data;
	private GameObject blackScreen;
	private int choosen = 0;
	private float end = 0;
	// Use this for initialization
	void Start () {
		data = GameObject.Find ("Data").GetComponent<Data> ();
		blackScreen = GameObject.Find ("Black Screen");
	}
	
	// Update is called once per frame
	void Update () {
		if (end > 0) {
			end -= Time.deltaTime;
			if (end <= 0) {
				SceneManager.LoadScene (data.lastScene);
			}
			return;
		}
		if (choosen == 1) {
			blackScreen.GetComponent<GradientColorChanger> ().enabled = true;
			end = blackScreen.GetComponent<GradientColorChanger> ().endChange;
			return;
		}
		if (choosen == 2) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			choosen = 1;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			choosen = 2;
		}
	}
}
