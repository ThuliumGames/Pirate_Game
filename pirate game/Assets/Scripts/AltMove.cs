using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltMove : MonoBehaviour {

float PlaceX;
float PlaceY;
bool CanPromptW = false;
float MoveSpeed;
public GameObject WaterPrompt;
public GameObject WaterMap;


	void Update () {
		if (GameObject.Find("Canvas/Water Prompt") == null) {

			PlaceX = (this.gameObject.transform.position.x);
			PlaceY = (this.gameObject.transform.position.y);

			if (Input.GetKey (KeyCode.W)) {
				this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, MoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, -MoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.A)) {
				this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(-MoveSpeed, 0, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(MoveSpeed, 0, 0);
			}
		}
	}
	
	void LateUpdate () {

		if (PlaceX != this.gameObject.transform.position.x) {
			if (PlaceY != this.gameObject.transform.position.y) {
				MoveSpeed = 0.05625f;
				if (PlaceX < this.gameObject.transform.position.x) {
					if (PlaceY < this.gameObject.transform.position.y){
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,-45);  //up right
					} else {
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,-135);//down right
					}
				} else {
					if (PlaceY < this.gameObject.transform.position.y){
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,45);//up left
					} else {
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,135);//down left
					}
				}
			} else {
				MoveSpeed = 0.075f;
				if (PlaceX < this.gameObject.transform.position.x) {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,-90);//right
				} else {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,90);//left
				}
			}
		} else {
			MoveSpeed = 0.075f;
			if (PlaceY != this.gameObject.transform.position.y) {
				if (PlaceY < this.gameObject.transform.position.y){
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,-0);//up
				} else {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,180);//down
				}
			}
		}
	}
	void OnCollisionEnter2D (Collision2D Hit) {
		if (Hit.gameObject.tag == "Water") {
			if (CanPromptW) {
				WaterPrompt.SetActive (true);
				CanPromptW = false;
			}
		}
	}
	void OnTriggerExit2D (Collider2D Hit) {
		if (Hit.gameObject.tag == "Shore") {
			WaterMap.GetComponent<Collider2D>().isTrigger = false;
			CanPromptW = true;
		}
	}
}
