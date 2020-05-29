using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepController : MonoBehaviour {

	public float speed;

	void Update() {
		Move();
	}

	void Move() {
		if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) {
			Vector3 translation = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			translation *= speed * Time.deltaTime;
			transform.position += translation;
		}
	}

}
