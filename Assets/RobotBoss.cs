using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBoss : MonoBehaviour {

	public GameObject ninja;
	bool facingLeft;
	bool facingRight;

	public Object bullet1;
	public Object bullet2;
	public Object bullet3;
	public int shootingSpeed;
	public ArrayList listOfBullets;

	public float shootingDelay;
	float delay;
	bool canShoot;

	public int healthRemaining;
	public GameObject headBoss;
	public int arrowDestroyTimer;

	// Use this for initialization
	void Start () {
		delay = shootingDelay;
		ninja = GameObject.FindGameObjectWithTag ("Player");
		healthRemaining = 30;
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		arrowDestroyTimer = 5;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//synchronize according to headboss movement
		this.transform.position = new Vector3 (headBoss.transform.position.x + (2.25f - 2.12f)/headBoss.transform.localScale.x, 
			headBoss.transform.position.y + (2.84f - 0.25f)/headBoss.transform.localScale.x, 
			headBoss.transform.position.z);
		//print (headBoss.transform.position);
		//print (this.transform.position);

		if (ninja.transform.position.x < this.transform.position.x) {
			//this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,180,0,0));
			this.transform.rotation = new Quaternion (0, 180, 0, 0);
			facingLeft = true;
			facingRight = false;

		} else {
			//this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,0,0,0));
			this.transform.rotation = new Quaternion (0, 0, 0, 0);
			facingLeft = false;
			facingRight = true;
		}

		if (canShoot) {
			if (facingLeft) {
				GameObject newbullet1 = (GameObject)Instantiate (bullet1, new Vector3(this.transform.position.x-2f/headBoss.transform.localScale.x, this.transform.position.y, this.transform.position.z), new Quaternion (0, 0, 0, 0));
				newbullet1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet1.gameObject, arrowDestroyTimer);
				GameObject newbullet2 = (GameObject)Instantiate (bullet2, new Vector3(this.transform.position.x-2f/headBoss.transform.localScale.x, this.transform.position.y+0.03f, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 330)));
				newbullet2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 2);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet2.gameObject, arrowDestroyTimer);
				GameObject newbullet3 = (GameObject)Instantiate (bullet3, new Vector3(this.transform.position.x-2f/headBoss.transform.localScale.x, this.transform.position.y-0.03f, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 30)));
				newbullet3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -2);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet3.gameObject, arrowDestroyTimer);
			}
			if (facingRight) {
				GameObject newbullet1 = (GameObject)Instantiate (bullet1, new Vector3(this.transform.position.x+2f/headBoss.transform.localScale.x, this.transform.position.y, this.transform.position.z), new Quaternion (0, 0, 0, 0));
				newbullet1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet1.gameObject, arrowDestroyTimer);
				GameObject newbullet2 = (GameObject)Instantiate (bullet2, new Vector3(this.transform.position.x+2f/headBoss.transform.localScale.x, this.transform.position.y+0.03f, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 220)));
				newbullet2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 2);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet2.gameObject, arrowDestroyTimer);
				GameObject newbullet3 = (GameObject)Instantiate (bullet3, new Vector3(this.transform.position.x+2f/headBoss.transform.localScale.x, this.transform.position.y+0.03f, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 150)));
				newbullet3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -2);
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newbullet3.gameObject, arrowDestroyTimer);
			}
			canShoot = false;


		}

		if (this.transform.parent.GetComponent<IntegratedBossController> ().dropdownEnded) {
			if (delay == 0) {
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", true);
				canShoot = true;
				delay = shootingDelay;
			} else {
				delay--;
			}
		}

		if (healthRemaining <= 0) {
			Die ();
		}


	}

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
			}
		}
	}
}
