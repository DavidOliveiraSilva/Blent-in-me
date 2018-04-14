using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {
	private GradientColorChanger gcc;
	private AudioManager audioManager;
	// Use this for initialization
	void Start () {
		gcc = GetComponent<GradientColorChanger> ();
		audioManager = AudioManager.instance;
		audioManager.PlaySound ("Logo");
	}
	
	// Update is called once per frame
	void Update () {
		if (gcc.IsDone ()) {
			SceneManager.LoadScene ("MenuTitle");
			audioManager.PlaySound ("Searching Life");
		}
	}
}
