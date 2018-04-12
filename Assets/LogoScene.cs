using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LogoScene : MonoBehaviour {
	private GradientColorChanger gcc;
	// Use this for initialization
	void Start () {
		gcc = GetComponent<GradientColorChanger> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gcc.IsDone ()) {
			EditorSceneManager.LoadScene ("MenuTitle");
		}
	}
}
