using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Transform jinjaTransform = null;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		Vector3 current = GetComponent<Transform>().position;

		Vector3 target = jinjaTransform.position + Vector3.up;

		target.z = current.z;

		Vector3 newPosition = Vector3.Lerp(current, target, 0.1f);

		GetComponent<Transform>().position = newPosition;

	}
}
