using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {

	public Object ninja;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*void OnCollisionEnter2D(Collision2D col)
	{
		print (gameObject);
		Destroy(gameObject);
	}*/

	void OnCollisionEnter2D(Collision2D col)
	{
		//print ("Yah");
		//print (col.gameObject.tag);
		if (col.gameObject.tag.Equals ("Player")) {
			print ("Yeah");

			GameObject ninjaGameObj = (GameObject)ninja;

			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players) {
				//print (player.transform.parent.tag);
				/*foreach (GameObject child in player.GetComponentsInChildren<GameObject>(false)) {
						print (child.tag);

				}*/


				if (player.transform.parent != null) {
					//print ("is this detected?");
					if (player.transform.parent.tag == "Level1") {
						player.GetComponent<Ninja> ().livesRemaining--;
						Destroy (gameObject);
					}
				}
				if (player.transform.parent != null) {
					if (player.transform.parent.tag == "Level2") {
						player.GetComponent<Ninja> ().livesRemaining--;
						Destroy (gameObject);
					}
				}
				if (player.transform.parent != null) {
					print (player.transform.parent.tag);
					if (player.transform.parent.tag == "Level3") {
						print ("is this detected?");
						player.GetComponent<Ninja> ().livesRemaining--;
						Destroy (gameObject);
					}
				}
				}
		}

	}

	/*void OnTriggerEnter2D(Collider2D col)
	{
		//print ("Yah");
		//print (col.gameObject.tag);
		if (col.gameObject.tag.Equals ("Player")) {
			//print ("Yeah");
			GameObject ninjaGameObj = (GameObject)ninja;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().livesRemaining--;
			Destroy (gameObject);
		}

	}*/
}
