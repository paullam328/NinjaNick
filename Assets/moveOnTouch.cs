using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnTouch : MonoBehaviour {
	
	[SerializeField]
	public Vector3 velocity;

	public bool moving; 
	public GameObject collidingPlayer;
	
	// Update is called once per frame
	/*void FixedUpdate () {
		if (moving)
			transform.position += (velocity * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			moving = true;
			col.collider.transform.SetParent (transform);
		}
	}
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			col.collider.transform.SetParent (null);
			moving = false;
		}	
	}*/

	void FixedUpdate () {
		if (moving) {
			transform.position += (velocity * Time.deltaTime);
			collidingPlayer.transform.position += (velocity * Time.deltaTime);
		}
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			moving = true;

			//col.collider.transform.SetParent (transform);
			//col.collider.transform.position = gameObject.transform.position;

		}
	}
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			//col.collider.transform.SetParent (null);

			moving = false;
		}	
	}

}
