using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	
	float time;
	float SpeedX;
	float SpeedY;
	public float Power;
	public float ShootTime;
	public GameObject CBall;
	public GameObject LandPrompt;
	bool CanPromptL = true;
	Quaternion RotCorrect;

	void Start () {
		time = ShootTime;
	}
	
	void Update () {
		if (GameObject.Find("Canvas/Land Prompt") == null) {
			transform.rotation = RotCorrect;

			SpeedY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
			SpeedX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);

			time += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Space)) {
				if (time >= ShootTime) {
					time = 0;

					foreach (GameObject G in GameObject.FindGameObjectsWithTag("CannonP1")) {
						GameObject GO; 
						GO = Instantiate (CBall, G.transform.position, transform.rotation);
						GO.GetComponent<Rigidbody2D>().AddForce (G.transform.up * Power);
					}
				}
			}

			if (GetComponent<Rigidbody2D>().drag < 1) {
				GetComponent<Rigidbody2D>().drag = 1;
			}

			if (GetComponent<Rigidbody2D>().drag > 5) {
				GetComponent<Rigidbody2D>().drag = 5;
			}
			if (Input.GetKey (KeyCode.W)) {
				if (SpeedY < 8 && SpeedX < 8) {
					GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
					if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
						if (GetComponent<Rigidbody2D>().drag < 5) {
							GetComponent<Rigidbody2D>().drag += Time.deltaTime;
						}
					} else {
						if (GetComponent<Rigidbody2D>().drag > 1) {
							GetComponent<Rigidbody2D>().drag -= Time.deltaTime;
						}
					}
				}
			} else {
				GetComponent<Rigidbody2D>().drag += (Time.deltaTime/2);
			}

			if (Input.GetKey (KeyCode.S)) {
				GetComponent<Rigidbody2D>().AddForce(-transform.up * 20);
			}

			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
				if (SpeedX < 1 && SpeedY < 1) { 
					if (!Input.GetKey (KeyCode.S)) {
						GetComponent<Rigidbody2D>().AddForce(transform.up * 30);
					} else { 
						GetComponent<Rigidbody2D>().AddForce(-transform.up * 20);
					}
				}
			}

			if (Input.GetKey (KeyCode.D)) {	
				transform.Rotate(-Vector3.forward * 30 * Time.deltaTime);
				if (SpeedX < 3 && SpeedY < 3) { 
					if (!Input.GetKey (KeyCode.S)) {
						GetComponent<Rigidbody2D>().AddForce(transform.up * 30);
					} else { 
						GetComponent<Rigidbody2D>().AddForce(-transform.up * 20);
					}
				}
			}

			RotCorrect = this.gameObject.transform.rotation;
		}
	}
	void OnCollisionEnter2D (Collision2D Hit) {
		if (CanPromptL) {
			if (Hit.gameObject.tag == "Land") {
				CanPromptL = false;
				LandPrompt.SetActive (true);
			}
		}
	}
	void OnTriggerExit2D (Collider2D Hit) {
		if (Hit.gameObject.tag == "Shore") {
			CanPromptL = true;
		}
	}
}
