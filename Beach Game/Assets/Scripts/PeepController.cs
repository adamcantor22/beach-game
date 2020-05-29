using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float jumpForce;
	bool canJump = true;
	Rigidbody rb;

	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update() {
		Move();
		Rotate();
	}

	void Move() {
		if(Input.GetAxis("Vertical") != 0f) {
			Vector3 translation = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
			translation *= moveSpeed * Time.deltaTime;
			transform.Translate(translation);
		}
	}

	void Rotate() {
		if(Input.GetAxis("Horizontal") != 0f) {
			Vector3 rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);
			rotation *= rotateSpeed * Time.deltaTime;
			transform.Rotate(rotation);
		}
	}

	void Jump() {
		// if(Input.GetAxis("Jump") != 0 && canJump) {
		// 	rb.AddForce()
		// }
	}

}
