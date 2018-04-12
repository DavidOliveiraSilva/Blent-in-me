using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {
	public float duration;
	public float maxRadius;
	private float currentRadius = 0;
	private bool activated = false;
	private float time = 0;
	private CameraController cc;
	private int parity = 0;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			time += Time.deltaTime;
			if (time < duration) {
				if (time < duration * 0.5f) {
					currentRadius += (Time.deltaTime * maxRadius)/duration;
				} else {
					currentRadius -= (Time.deltaTime * maxRadius)/duration;
				}
				if (parity == 0) {
					transform.position = new Vector3 (transform.position.x + Random.Range (-currentRadius * 0.5f, currentRadius * 0.5f), transform.position.y + Random.Range (-currentRadius * 0.5f, currentRadius * 0.5f), transform.position.z);
					parity = 1;
				} else {
					transform.position = cc.GetFollowPosition ();
					parity = 0;
				}
			} else {
				time = 0;
				activated = false;
				currentRadius = 0;
				cc.ToggleShaking ();
			}
		}
	}
	public void Shake(){
		activated = true;
		cc.ToggleShaking ();
	}
}
