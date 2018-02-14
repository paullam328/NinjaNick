using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerArcherController : MonoBehaviour {

	public GameObject ninja;
	bool facingLeft;
	bool facingRight;

	public Object arrow;
	public int shootingSpeed;
	public ArrayList listOfArrows;

	public float shootingDelay;
	float delay;
	bool canShoot;

	public int healthRemaining;
	int yMultiply;


	// Use this for initialization
	void Start () {
		delay = shootingDelay;
		ninja = GameObject.FindGameObjectWithTag ("Player");
		healthRemaining = 30;
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
				if (this.transform.parent.tag == "Level1") {
					yMultiply = 4;
				} else {
					yMultiply = 1;
				}
			}
			if (facingLeft) {
					GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3(this.transform.position.x, this.transform.position.y - 0.25f/yMultiply, this.transform.position.z), new Quaternion (0, 0, 0, 0));
				newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);
				this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newarrow.gameObject, 2);
			}
			if (facingRight) {
					GameObject newarrow = (GameObject)Instantiate (arrow, new Vector3(this.transform.position.x, this.transform.position.y - 0.25f/yMultiply, this.transform.position.z), new Quaternion (0, 0, 0, 0));
				newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
				this.gameObject.GetComponent<Animator> ().SetBool ("IsShooting", false);
				Destroy(newarrow.gameObject, 2);
			}
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
