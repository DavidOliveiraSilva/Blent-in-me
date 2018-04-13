using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float speed;
	public SpringJoint2D[] joints;
	private int jointCount = 0;
	public float expelingForce;
	private GameObject camera;
	public GameObject ripple1;
	public GameObject ripple2;
	public float maxHealth;
	public float health;
	public float hpDecayRate = 10;
	public bool active = true;
	private float gameOver = 0;
	private AudioManager audioManager;
	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		rb2d = GetComponent<Rigidbody2D>();
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver > 0) {
			gameOver -= Time.deltaTime;
			if (gameOver <= 0) {
				SceneManager.LoadScene ("GameOver");
			}
			return;
		}
		if (active) {
			float hor = Input.GetAxis ("Horizontal");
			float ver = Input.GetAxis ("Vertical");
			rb2d.AddForce (new Vector2 (hor * speed, ver * speed));
			if (jointCount == 0) {
				health -= Time.deltaTime * hpDecayRate;
				if (health <= 0) {
					health = 0;
					active = false;
					gameOver = camera.GetComponent<CameraController> ().TransitionToGameOver ();
				}
			} else {
				health += Time.deltaTime * hpDecayRate;
				if (health >= maxHealth) {
					health = maxHealth;
				}
			}
			for (int i = 0; i < joints.Length; i++) {
				if (joints [i] != null) {
					if (joints [i].connectedBody.gameObject.GetComponent<Cell> ().state == "decay") {
						GameObject r = Instantiate (ripple2);
						r.transform.position = joints[i].connectedBody.transform.position;
						joints [i].connectedBody = null;
						Destroy (joints [i]);
						joints [i] = null;
						camera.GetComponent<ShakeCamera> ().Shake ();
						jointCount--;
						audioManager.PlaySound ("Decay");
						break;
					}
				}
			}
		}


	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Cell" && coll.gameObject.GetComponent<Cell>().state == "free") {
			for (int i = 0; i < joints.Length; i++) {
				if (joints [i] == null) {
					joints [i] = gameObject.AddComponent<SpringJoint2D> ();
					jointCount++;
					joints [i].connectedBody = coll.gameObject.GetComponent<Rigidbody2D> ();
					joints [i].distance = 0.3f;
					joints [i].dampingRatio = 1f;
					coll.gameObject.GetComponent<Cell>().state = "jointed";
					GameObject r = Instantiate (ripple1);
					r.transform.position = joints[i].connectedBody.transform.position;
					audioManager.PlaySound ("Cell");
					return;
				}
			}

		}
	}
	void FreeNullJoints(){
		

	}
}
