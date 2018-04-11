using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public string state = "free";
	private float time = 0;
	public float multiplier = 1;
	public float decay = 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (state == "jointed") {
			time += Time.deltaTime*multiplier;
			if (time >= decay) {
				state == "decay";
			}
		}
		if (state == "decay") {

		}
	}
}
