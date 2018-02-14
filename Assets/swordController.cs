using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour {

	public Object ninja;

	public Transform[] points;
	Transform currentPatrolPoint;

	private int destPoint = 0;
	public float speed;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		currentPatrolPoint = points [destPoint];
		direction = Vector3.up;
	}
	void GoBack (){
		if (destPoint == 0) {
			destPoint = 1;
			currentPatrolPoint = points [destPoint];
			direction = Vector3.down;
		} else {
			destPoint = 0;
			currentPatrolPoint = points [destPoint];
			direction = Vector3.up;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (this.transform.position, currentPatrolPoint.position) < 0.5f) {
			GoBack ();
		}
		transform.Translate (direction* Time.deltaTime * speed);
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().livesRemaining--;
			Destroy (gameObject);
		}

	}
}
