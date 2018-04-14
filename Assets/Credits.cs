using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
	private GameObject blackScreen;
	private bool fading = false;
	private float time;
	private AudioManager audioManager;
	// Use this for initialization
	void Start () {
		blackScreen = GameObject.Find ("Black Screen");
		audioManager = AudioManager.instance;
		if (audioManager.IsPlaying ("Searching Life")) {
			audioManager.StopSound ("Searching Life");
			audioManager.PlaySound ("Blent in Me");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			time -= Time.deltaTime;
			if (time <= 0) {
				audioManager.StopSound ("Blent in Me");
				SceneManager.LoadScene ("Logo");
			}
		}
		if (Input.anyKeyDown) {
			blackScreen.GetComponent<GradientColorChanger> ().enabled = true;
			time = blackScreen.GetComponent<GradientColorChanger> ().endChange;
		}
	}
}
