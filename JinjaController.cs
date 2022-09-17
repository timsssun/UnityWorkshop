using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		//check if the arrow key is down, move jinja
		if (Input.GetKey(KeyCode.RightArrow)) {
			GetComponent<Transform>().position += Vector3.right;
		}
	}
}
