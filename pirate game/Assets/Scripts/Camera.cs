using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public GameObject Boat;
	public GameObject Man;

	void Start () {
		
	}

	void Update () {
		if (GameObject.Find("Player") != null) {
			this.gameObject.transform.position = Boat.transform.position + new Vector3 (0, 0, -10);
		}
		if (GameObject.Find("Player 2") != null) {
			this.gameObject.transform.position = Man.transform.position + new Vector3 (0, 0, -10);
		}
	}
}
