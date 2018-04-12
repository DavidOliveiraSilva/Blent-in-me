using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private Vector3 followPosition;
	private bool shaking = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerCore");
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
}
