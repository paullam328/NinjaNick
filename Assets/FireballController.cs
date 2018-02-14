using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("AdvancedArcher")) {
			GameObject.FindGameObjectWithTag ("AdvancedArcher").GetComponent<AdvancedArcherController> ().healthRemaining -= 30;
			Destroy (gameObject);
		}
		if (col.gameObject.tag.Equals ("RookieArcher")) {
			GameObject.FindGameObjectWithTag ("RookieArcher").GetComponent<BeginnerArcherController> ().healthRemaining -= 30;
			Destroy (gameObject);
		}
		if (col.gameObject.tag.Equals ("Patroller")) {
			GameObject.FindGameObjectWithTag ("Patroller").GetComponent<PatrollerController> ().healthRemaining -= 30;
			Destroy (gameObject);
		}
		if (col.gameObject.tag.Equals ("BigBoss")) {
			print ("called");
			GameObject.FindGameObjectWithTag ("BigBigBoss").GetComponent<IntegratedBossController> ().healthRemaining -= 30;
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("Missile")) {
			Destroy (col.gameObject);
			Destroy (gameObject);
			//print ("yep");
		}
	}
}
