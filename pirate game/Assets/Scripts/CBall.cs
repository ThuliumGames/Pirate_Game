using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBall : MonoBehaviour {

	public GameObject Splash;
	public float CballTime;

	float HalfTime;
	float UpTime = 0;
	float time = 0;
	

	void Start () {
		HalfTime = CballTime / 2;
	}

	void Update () {
		time += Time.deltaTime;

		if (time < HalfTime) {
			UpTime += Time.deltaTime;
		} else {
			UpTime -= Time.deltaTime;
		}

		this.gameObject.transform.localScale = new Vector3(0.5f + UpTime, 0.5f + UpTime, 0.5f);
		
		if (time >= CballTime) {
			Instantiate (Splash, transform.position, Quaternion.Euler(0,0,0));
			Destroy (gameObject);
		}
	}
}
