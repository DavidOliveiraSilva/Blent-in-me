using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private Vector3 followPosition;
	private bool shaking = false;
	private GradientColorChanger[] colorChanger;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerCore");
		colorChanger = GetComponentsInChildren<GradientColorChanger> ();
		Open ();
	}
	
	// Update is called once per frame
	void Update () {
		followPosition = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
		if (!shaking) {
			transform.position = followPosition;
		}
	}
	public Vector3 GetFollowPosition(){
		return followPosition;
	}
	public void ToggleShaking(){
		if (shaking) {
			shaking = false;
		} else {
			shaking = true;
		}
	}
	public void Open(){
		colorChanger [0].enabled = false;
		colorChanger [1].enabled = true;
		colorChanger [2].enabled = false;
	}
	public float Close(){
		colorChanger [0].enabled = true;
		colorChanger [1].enabled = false;
		colorChanger [2].enabled = false;
		return colorChanger [0].endChange;
	}
	public float TransitionToGameOver(){
		colorChanger [0].enabled = false;
		colorChanger [1].enabled = false;
		colorChanger [2].enabled = true;
		return colorChanger [2].endChange;
	}
}
