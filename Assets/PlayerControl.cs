using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float speed;
	public SpringJoint2D[] joints;
	private int jointCount = 0;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		rb2d.AddForce( new Vector2(hor*speed, ver*speed));
		for (int i = 0; i < joints.Length; i++) {
			if (joints [i] != null) {
				if (joints [i].connectedBody.gameObject.GetComponent<Cell> ().state == "decay") {
					joints [i].connectedBody = null;
					Destroy (joints [i]);
					joints [i] = null;
					break;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Cell" && coll.gameObject.GetComponent<Cell>().state == "free") {
			for (int i = 0; i < joints.Length; i++) {
				if (joints [i] == null) {
					joints [i] = gameObject.AddComponent<SpringJoint2D> ();
					joints [i].connectedBody = coll.gameObject.GetComponent<Rigidbody2D> ();
					joints [i].distance = 0.3f;
					joints [i].dampingRatio = 1f;
					coll.gameObject.GetComponent<Cell>().state = "jointed";
					return;
				}
			}

		}
	}
	void FreeNullJoints(){
		

	}
}
