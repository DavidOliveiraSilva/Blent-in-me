using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public string state = "free";
	private float time = 0;
	public float multiplier = 1;
	public float decay = 5;
	private ParticleSystem ps;
	private bool changedColor = false;
	public Gradient decayColor;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (state == "jointed") {
			time += Time.deltaTime*multiplier;
			if (time >= decay) {
				state = "decay";
			}
		}
		if (state == "decay") {
			if (!changedColor) {
				int qtd = ps.main.startColor.gradient.colorKeys.Length;
				var psmain = ps.main;
				psmain.startColor = new ParticleSystem.MinMaxGradient (decayColor);
				changedColor = true;
			}
		}
	}
}
