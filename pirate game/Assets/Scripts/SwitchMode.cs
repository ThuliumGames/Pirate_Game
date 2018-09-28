using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour {

	public GameObject Boat;
	public GameObject LandPlayer;
	public GameObject LandMap;
	public GameObject WaterMap;
	public GameObject LandPrompt;
	public GameObject WaterPrompt;
	bool OnLand = false;

	public void LandYes_OnClick() {
		if(!OnLand) {
			WaterMap.GetComponent<Collider2D>().isTrigger = false;
			LandPrompt.SetActive(false);
			LandPlayer.transform.position = Boat.transform.position;
			LandPlayer.transform.rotation = Boat.transform.rotation;
			OnLand = true;
		}
	}

	public void WaterYes_OnClick() {
		if(OnLand) {
			WaterMap.GetComponent<Collider2D>().isTrigger = true;
			WaterPrompt.SetActive(false);
			Boat.transform.position = LandPlayer.transform.position;
			Move.RotCorrect = LandPlayer.transform.rotation;
			OnLand = false;
		}
	}
	void Update () {
		if (OnLand) {
			LandMap.GetComponent<Collider2D>().isTrigger = true;
			Boat.SetActive(false);
			LandPlayer.SetActive(true);
		} else {
			LandMap.GetComponent<Collider2D>().isTrigger = false;
			Boat.SetActive(true);
			LandPlayer.SetActive(false);
		}
	}
}
