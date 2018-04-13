using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mother : MonoBehaviour {
	private SpringJoint2D joint;
	private float end;
	private bool ending = false;
	public string nextSceneName;
	private AudioManager audioManager;
	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if (ending) {
			end -= Time.deltaTime;
			if (end <= 0) {
				SceneManager.LoadScene (nextSceneName);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (ending) {
			return;
		}
		if (other.tag == "Player") {
			audioManager.PlaySound ("Mother");
			other.GetComponent<PlayerControl> ().active = false;
			joint = gameObject.AddComponent<SpringJoint2D> ();
			joint.connectedBody = other.gameObject.GetComponent<Rigidbody2D> ();
			joint.distance = 0.3f;
			end = GameObject.Find ("Main Camera").GetComponent<CameraController> ().Close ();
			ending = true;
		}
	}
}
