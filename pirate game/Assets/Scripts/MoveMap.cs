using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour {
	Vector3 NewCamPos;

	public GameObject MapCam;
	void Start () {
	}
	
	void Update () {
		//if (!GetComponent <SpriteRenderer>().isVisible) {
			if (transform.position.x > NewCamPos.x + 50) {
				NewCamPos += new Vector3 (100, 0, 0);
			}
			if (transform.position.x < NewCamPos.x - 50) {
				NewCamPos += new Vector3 (-100, 0, 0);
			}
			if (transform.position.y > NewCamPos.y + 50) {
				NewCamPos += new Vector3 (0, 100, 0);
			}
			if (transform.position.y < NewCamPos.y - 50) {
				NewCamPos += new Vector3 (0, -100, 0);
			}
		//}

		if (MapCam.transform.position != NewCamPos){
			if (MapCam.transform.position.x < NewCamPos.x) {
				MapCam.transform.position += new Vector3 (2, 0, 0);
			}
			if (MapCam.transform.position.x > NewCamPos.x) {
				MapCam.transform.position += new Vector3 (-2, 0, 0);
			}
			if (MapCam.transform.position.y < NewCamPos.y) {
				MapCam.transform.position += new Vector3 (0, 2, 0);
			}
			if (MapCam.transform.position.y > NewCamPos.y) {
				MapCam.transform.position += new Vector3 (0, -2, 0);
			}
		}
	}
}
