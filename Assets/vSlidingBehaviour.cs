using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vSlidingBehaviour : MonoBehaviour {

	private Vector3 pos1 = new Vector3(0,-3,0);
	private Vector3 pos2 = new Vector3(0,3,0);
	public float speed;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();

	}
	// Update is called once per frame
	void FixedUpdate() {
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
	}

}
