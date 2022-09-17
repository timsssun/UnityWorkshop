using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour {

	//field for acceleration
	[SerializeField]
	float acceleration = 0.1f;

	//field for friction
	[SerializeField]
	float friction = 0.9f;

	//field for gravity
	[SerializeField]
	float gravity = 0.02f;

	Vector3 velocity = Vector3.zero;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		Transform tf = GetComponent<Transform>();

		//add friction to Jinja
		velocity *= friction;

		//add gravity
		velocity += Vector3.down * gravity;

		//check if the arrow key is down, move jinja
		if (Input.GetKey(KeyCode.RightArrow)) {
			velocity += Vector3.right * acceleration;
		}

		//check if left arrow key is down, move jinja left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			velocity += Vector3.left * acceleration;
		}

		tf.position += velocity;
	}
}
