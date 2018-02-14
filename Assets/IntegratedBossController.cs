using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegratedBossController : MonoBehaviour {

	public int healthRemaining = 600;

	public Transform[] points;
	Transform currentPatrolPoint;

	private int destPoint;
	public int speed;
	int direction;

	public bool dropdownEnded;
	public bool isDroppingDown;
	public float dropdownSpeed;
	public GameObject dropdownPoint;
	public float dropdownDecrement;
	public float delayTimer;

	private int verticalDestPoint;
	public Transform[] verticalPatrolPoints;
	Transform currentVerticalPatrolPoint;
	public GameObject lowPoint;
	public float verticalPatrolSpeed;

	Vector3 previous;
	float velocity;
	float lastVelocity;

	public GameObject headBoss;
	public bool headCanShoot;

	// Use this for initialization
	void Start () {
		healthRemaining = 600;
		dropdownDecrement = 0;
		dropdownEnded = false;

		verticalDestPoint = 1;
		currentVerticalPatrolPoint = verticalPatrolPoints [verticalDestPoint];
		direction = -1;
		headCanShoot = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//print(Vector3.Distance (headBoss.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));

		velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		previous = transform.position;

		var acceleration = (velocity - lastVelocity) / Time.deltaTime;
		lastVelocity = velocity;
		//print (acceleration);
		//print (velocity);

		//print (Vector3.Distance (headBoss.transform.position, dropdownPoint.transform.position));
		if (Vector3.Distance(headBoss.transform.position,dropdownPoint.transform.position)>0.2f) {
			DropDown ();
		} else {
			headBoss.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			if (delayTimer > 0) {
				delayTimer -= 1 * Time.deltaTime;
			} else {
				isDroppingDown = false;
				dropdownEnded = true;
			}
		}

		if (dropdownEnded) {
			PatrolProcedure ();
		}

		if (healthRemaining == 300) {
			SummonAllies ();
		}
		if (healthRemaining <= 0) {
			Die ();
		}

	}

	void Die() {
		Destroy (gameObject);
	}

	void DropDown() {
		if (Vector3.Distance (headBoss.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 6.5f && !dropdownEnded) {
			isDroppingDown = true;
			/*if (GameObject.FindGameObjectWithTag ("PrebossSong") != null) {
				GameObject.FindGameObjectWithTag ("PrebossSong").GetComponent<AudioSource> ().mute = true;
				//GameObject.FindGameObjectWithTag ("PrebossSong").SetActive (false);
			}
			GameObject.FindGameObjectWithTag ("BossSong").GetComponent<AudioSource> ().mute = false;*/
			//dropdownDecrement += 0.0075f * Time.deltaTime;
			headBoss.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1);
			//this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y-dropdownDecrement, this.transform.position.z);
			//print(Vector3.Distance(this.transform.position,dropdownPoint.transform.position));
		}
	}

	void SummonAllies () {
		//print("I need allies");
		/*transform.Translate 
		(new Vector3(Vector3.Distance(points[0].transform.position,points[1].transform.position)*new Vector3(1,1,0),1,0)* Time.deltaTime * speed);
		*/

	}
	void PatrolProcedure() {
		PatrolVertically ();
	}
	void PatrolVertically() {
		//print (currentVerticalPatrolPoint);
		//print (Vector3.Distance (this.transform.position, currentVerticalPatrolPoint.position));
		if (Vector3.Distance (headBoss.transform.position, currentVerticalPatrolPoint.position) < 0.5f) {
			headBoss.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			if (verticalDestPoint == 0) {
				headBoss.GetComponent<HeadbossController> ().shootCount = 0;
				headCanShoot = true;
				verticalDestPoint = 1;
				currentVerticalPatrolPoint = verticalPatrolPoints [verticalDestPoint];
				direction = -1;
			} else {
				headCanShoot = false;
				verticalDestPoint = 0;
				currentVerticalPatrolPoint = verticalPatrolPoints [verticalDestPoint];
				direction = 1;
			}
		}
		//transform.Translate (direction * Time.deltaTime * verticalPatrolSpeed);
		//transform.position += direction * verticalPatrolSpeed * Time.deltaTime;
		//print (direction * Time.deltaTime * verticalPatrolSpeed);
		headBoss.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, direction * 3);



	}

}
