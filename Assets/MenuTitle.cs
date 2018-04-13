using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitle : MonoBehaviour {
	public string firstSceneName;
	private AudioManager audioManager;
	private bool play = false;
	private GameObject blackScreen;
	private float time = 0;
	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		blackScreen = GameObject.Find ("Black Screen");
	}
	
	// Update is called once per frame
	void Update () {
		if (play) {
			time += Time.deltaTime;
			if (time >= blackScreen.GetComponent<GradientColorChanger> ().endChange) {
				SceneManager.LoadScene (firstSceneName);
			}
			return;
		}
		if (Input.anyKeyDown) {
			audioManager.PlaySound ("Play");
			blackScreen.GetComponent<GradientColorChanger> ().enabled = true;
			play = true;
		}

	}
}
