using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatrollerController : MonoBehaviour {

	//private NavMeshAgent agent;
	public int speed;
	public Transform[] points;
	private int destPoint = 0;
	Transform currentPatrolPoint;

	public int healthRemaining;


	// Use this for initialization
	void Start () {

		healthRemaining = 90;
		currentPatrolPoint = points [destPoint];
	}

	void GoToNextPoint() {
		//transform.Translate (Vector3.right * Time.deltaTime * speed);
		transform.Rotate(0,180,0);
		if (destPoint == 0) {
			destPoint = 1;
			currentPatrolPoint = points [destPoint];
		} else {
			destPoint = 0;
			currentPatrolPoint = points [destPoint];
		}
	}

	// Update is called once per frame
	void Update () {
		//print (Vector3.Distance (transform.position, currentPatrolPoint.transform.position));
		if (Vector3.Distance (transform.position, currentPatrolPoint.transform.position) < 1f) {
			//print ("yes");
			GoToNextPoint ();
		}
		else {
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}

		if (healthRemaining <= 0) {
			Die ();
		}
		
	}

	/*public LayerMask enemyMask;
	public float speed;
	Rigidbody2D rb;
	Transform trans;
	float width;
	void Start () {
		trans = this.transform;
		rb = this.GetComponent<Rigidbody2D> ();
		width = this.GetComponent<SpriteRenderer> ().bounds.extents.x;

	}

	void FixedUpdate(){

		Vector2 lineCastPos = trans.position - trans.right * width;
		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down,enemyMask);

		//Always move forward
		Vector2 myVel = rb.velocity;
		myVel.x = speed;
		rb.velocity = myVel;
	}*/

	void Die() {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//print ("Yah");
		//print (col.gameObject.tag);
		if (col.gameObject.tag.Equals ("Player")) {
			//print ("Yeah");
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible == false) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().livesRemaining--;
				Destroy (gameObject);
			}
		}
	}

}
