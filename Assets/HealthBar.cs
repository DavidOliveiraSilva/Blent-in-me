using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	private ParticleSystem ps;
	private PlayerControl player;
	private Vector3 oScale; //escala original;
	private float oEmission;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerCore").GetComponent<PlayerControl> ();
		ps = GetComponent<ParticleSystem> ();
		oScale = transform.localScale;
		oEmission = ps.emission.rateOverTime.constant;
	}
	
	// Update is called once per frame
	void Update () {
		float health = player.health/player.maxHealth;
		transform.localScale = new Vector3 (oScale.x * health, oScale.y * health, oScale.z * health);
		var emission = ps.emission;
		emission.rateOverTime = new ParticleSystem.MinMaxCurve (oEmission * health);
	}
}
