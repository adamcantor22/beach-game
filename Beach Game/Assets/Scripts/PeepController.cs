using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float jumpForce;
	bool onGround = false;
	Rigidbody rb;

	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update() {
		Gravity();
		Move();
		Rotate();
		Jump();
	}


	void OnCollisionExit(Collision other) {
		if(other.gameObject.tag == "StandableSurface") {
			onGround = false;
		}
	}

	void OnCollisionStay(Collision other) {
		if(!onGround && other.gameObject.tag == "StandableSurface") {
			onGround = true;
		}
	}

	void Gravity() {
		if(!onGround) {
			rb.AddForce(Physics.gravity);
		}
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
		if(Input.GetAxis("Jump") != 0 && onGround) {
			Vector3 jumpVector = new Vector3(0f, jumpForce, 0f);
		 	rb.AddForce(jumpVector);
			Debug.Log("jumpin");
			onGround = false;
		}
	}

}
