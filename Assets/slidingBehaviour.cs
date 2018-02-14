using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingBehaviour : MonoBehaviour {
	
	private Vector3 pos1 = new Vector3(-1,0,0);
	private Vector3 pos2 = new Vector3(1,0,0);
	public float speed = 1.0f;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();

	}
	// Update is called once per frame
	void Update() {
		rb.velocity = new Vector3(-1f * speed,0,0);	
	}

}
