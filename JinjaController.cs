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

	//field for jump
	[SerializeField]
	float jump = 0.3f;

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

		//jumping
		if (Input.GetKeyDown(KeyCode.Space)) {
			//is jinja on a platform?
			RaycastHit2D hitPlatform = Physics2D.Raycast(tf.position, Vector3.down, 0.1f);
			if (hitPlatform.collider != null) {
				//jump!
				velocity.y = jump;
			}
		}

		tf.position += velocity;

		//Raycast to detect platforms
		Vector3 origin = tf.position - velocity;

		Vector3 direction = velocity;

		float length = velocity.magnitude;

		//shoot a ray from Jinja's feet in the direction she's going
		RaycastHit2D hit = Physics2D.Raycast(origin, direction, length);

		//did the ray hit a platform AND is jinja falling?
		if (hit.collider != null && velocity.y < 0) {
			//place Jinja's position above the playform
			tf.position = new Vector3(tf.position.x, hit.point.y, tf.position.z);

			//reset y velocity
			velocity.y = 0;
		}

		//Animation

		Animator animator = GetComponentInChildren<Animator>();
		animator.ResetTrigger("Idle");
		animator.ResetTrigger("Run");
		animator.ResetTrigger("Jump");

		//play run animation
		RaycastHit2D hitGroud = Physics2D.Raycast(tf.position, Vector3.down, 0.1f);
		if (hitGroud.collider == null) {
			animator.SetTrigger("Jump");

		} else if (Input.GetKey(KeyCode.RightArrow) ||
			  Input.GetKey(KeyCode.LeftArrow) ||
			  Mathf.Abs(velocity.x) >= acceleration) {
			//if keys are down or jinja is moving
			animator.SetTrigger("Run");

		} else {
			//jinja is not moving
			animator.SetTrigger("Idle");
			velocity.x = 0;
		}

		//change direction Jinja is facing
		if (Mathf.Abs(velocity.x) >= acceleration) { //if jinja is moving

			float directionSign = Mathf.Sign(velocity.x);
			tf.localScale = new Vector3(directionSign, 1, 1);
		}

		//respawn
		if (tf.position.y < -10) {
			tf.position = Vector3.zero;
			velocity = Vector3.zero;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Finish") {
			GetComponent<AudioSource>().Play();
		}
	}
}
