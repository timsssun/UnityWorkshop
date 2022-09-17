using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		Transform tf = GetComponent<Transform>();

		//check if the arrow key is down, move jinja
		if (Input.GetKey(KeyCode.RightArrow)) {
			tf.position += Vector3.right * 0.1f;
		}

		//check if left arrow key is down, move jinja left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			tf.position += Vector3.left * 0.1f;
		}
	}
}
