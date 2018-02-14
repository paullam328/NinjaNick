using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbossController : MonoBehaviour {

	public GameObject ninja;
	bool facingLeft;
	bool facingRight;

	public Object missile;
	public int shootingSpeed;
	public ArrayList listOfBullets;

	public float shootingDelay;
	float delay;
	bool canShoot;

	public int healthRemaining;

	int missileCounter;
	int missileType;
	public int shootCount;

	public int missileDestroyTimer;


	// Use this for initialization
	void Start () {
		delay = shootingDelay;
		ninja = GameObject.FindGameObjectWithTag ("Player");
		healthRemaining = 30;
		canShoot = false;

		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		missileDestroyTimer = 5;


	}

	// Update is called once per frame
	void FixedUpdate () {
		//print (this.gameObject.GetComponent<Rigidbody2D> ().velocity);

		if (ninja.transform.position.x < this.transform.position.x) {
			//this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,0,0,0));
			this.transform.rotation = new Quaternion (0, 0, 0, 0);
			facingLeft = true;
			facingRight = false;

		} else {
			//this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,180,0,0));
			this.transform.rotation = new Quaternion (0, 180, 0, 0);
			facingLeft = false;
			facingRight = true;
		}

		if (canShoot && shootCount < 1) {

			Vector3 spawnPoint = new Vector3 (this.transform.position.x - 2.2f/transform.localScale.x, this.transform.position.y - 1.6f/transform.localScale.y, this.transform.position.z);

			if (facingLeft) {
				if (missileType == 0) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, new Quaternion (0, 0, 0, 0));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);
					Destroy(newMissile.gameObject, missileDestroyTimer);
				}
				if (missileType == 1) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 20)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -1f);
					Destroy(newMissile.gameObject, missileDestroyTimer);
				}
				if (missileType == 2) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 30)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -2f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 3) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 40)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -3);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 4) {
					GameObject newMissile = (GameObject)Instantiate (missile,spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 50)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -4f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 5) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 70)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -5f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 6) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 80)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -6f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 7) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 0, 90)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, -7f);
					Destroy(newMissile.gameObject, missileDestroyTimer);
					missileType = -1;
					delay += 100;
					shootCount++;
				}
				//GameObject newarrow4 = (GameObject)Instantiate (arrow, new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z), Quaternion.Euler(new Vector3(0,0,270)));

				//newarrow3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 4);
			}
			if (facingRight) {//90-180 degrees
				if (missileType == 0) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, new Quaternion (0, 180, 0, 0));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
					Destroy(newMissile.gameObject, missileDestroyTimer);
				}
				if (missileType == 1) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 20)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -1f);
					Destroy(newMissile.gameObject, missileDestroyTimer);
				}
				if (missileType == 2) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 30)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -3f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 3) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 40)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -5);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 4) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 50)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -9f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 5) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 70)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -13f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 6) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 80)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -16f);
					Destroy(newMissile.gameObject, missileDestroyTimer);

				}
				if (missileType == 7) {
					GameObject newMissile = (GameObject)Instantiate (missile, spawnPoint, Quaternion.Euler (new Vector3 (0, 180, 90)));
					newMissile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, -20f);
					Destroy(newMissile.gameObject, missileDestroyTimer);
					missileType = -1;
					delay += 500;
					shootCount++;
				}

			}
			//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
			missileType++;
			canShoot = false;


		}

		if (this.transform.parent.GetComponent<IntegratedBossController> ().dropdownEnded) {
			/*if (delay == 0) {
				//this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", true);
				canShoot = true;
				delay = shootingDelay;
			} else {
				delay--;
			}*/

			if (this.transform.parent.GetComponent<IntegratedBossController> ().headCanShoot) {
				if (shootCount < 1) {
					canShoot = true;
				}
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
