using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible == false) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().livesRemaining--;
			}
		}
	}
}
