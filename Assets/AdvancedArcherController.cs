using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedArcherController: MonoBehaviour {

	public GameObject ninja;
	bool facingLeft;
	bool facingRight;

	public Object arrow;
	public int shootingSpeed;
	public ArrayList listOfArrows;

	public float shootingDelay;
	float delay;
	bool canShoot;

	int arrowCounter;
	int arrowType;

	public int healthRemaining;

	public float yArrowInstance;
	public float xMultiply;

	// Use this for initialization
	void Start () {
		delay = shootingDelay;
		arrowType = 0;
		healthRemaining = 150;
		ninja = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (ninja.transform.position.x < this.transform.position.x) {
			this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,180,0,0));
			facingLeft = true;
			facingRight = false;

		} else {
			this.transform.SetPositionAndRotation(this.transform.position,new Quaternion(0,0,0,0));
			facingLeft = false;
			facingRight = true;
		}

		if (canShoot) {
			if (this.transform.parent != null) {
				if (this.transform.parent.tag == "Level1" || this.transform.parent.tag == "Level3") {
					yArrowInstance = this.transform.position.y - 0.08f;
					xMultiply = 4;
				}
				else {
					yArrowInstance = this.transform.position.y - 0.25f;
					xMultiply = 1;
				}
			} else {
				yArrowInstance = this.transform.position.y - 0.25f;
				xMultiply = 1;
			}
			//print ("xMultiply" + xMultiply);
			//print (this.transform.position.x - 0.2f / xMultiply);
			//print (this.transform.position.x + 0.2f / xMultiply);
			if (this.transform.position.x - 0.2f / xMultiply != Mathf.NegativeInfinity || this.transform.position.x + 0.2f / xMultiply != Mathf.Infinity) {
				if (facingLeft) {
					if (arrowType == 0) {
						GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x, yArrowInstance, this.transform.position.z), new Quaternion (0, 0, 0, 0));
						newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);
					}
					if (arrowType == 1) {
						GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x - 0.2f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 330)));
						newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 1);
					}
					if (arrowType == 2) {
						GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x - 0.4f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 310)));
						newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 2);
					}
					if (arrowType == 3) {
						GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x - 0.6f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 290)));
						newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 4);
						arrowType = -1;
					}
					//GameObject newarrow4 = (GameObject)Instantiate (arrow, new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z), Quaternion.Euler(new Vector3(0,0,270)));

					//newarrow3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 4);
				}
				if (facingRight) {
						if (arrowType == 0) {
							GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x, yArrowInstance, this.transform.position.z), new Quaternion (0, 0, 0, 0));
							newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
							Destroy (newarrow.gameObject, 2);
						}
						if (arrowType == 1) {
							GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x + 0.2f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, -160)));
							newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 1);
							Destroy (newarrow.gameObject, 2);
						}
						if (arrowType == 2) {
							GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x + 0.4f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, -140)));
							newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 2);
							Destroy (newarrow.gameObject, 2);
						}
						if (arrowType == 3) {
							GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3 (this.transform.position.x + 0.6f / xMultiply, yArrowInstance, this.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, -120)));
							newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 4);
							Destroy (newarrow.gameObject, 2);
							arrowType = -1;
						}
					}


			}
			this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
			arrowType++;
			canShoot = false;


		}

		if (delay == 0) {
			this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", true);
			canShoot = true;
			delay = shootingDelay;
		} else {
			delay--;
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
