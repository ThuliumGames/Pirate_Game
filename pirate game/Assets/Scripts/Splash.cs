using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

	float time;
	public float SplashTime;

	public float SplashSpeed;

	void Start () {
		
	}
	

	void Update () {
		time += Time.deltaTime;
		this.gameObject.transform.localScale = new Vector3(0.5f + time * SplashSpeed, 0.5f + time * SplashSpeed, 0.5f);
		if (time >= SplashTime) {
			Destroy(gameObject);
		}
	}
}
