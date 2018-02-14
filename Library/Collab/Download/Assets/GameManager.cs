using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject camera;
	public Object heart;
	public GameObject[] listOfHearts;
	public GameObject levelActivationAuthority;

	// Use this for initialization
	void Start () {
		//camera = GetComponent<Camera> ();
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			if (player.transform.parent.tag != "Level1") {
				player.transform.parent.gameObject.SetActive (false);
			}
			/*//TODO :Kenny test
			if (player.transform.parent.tag != "Level3") {
				player.transform.parent.gameObject.SetActive (false);
			}*/
				
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		//if (GameObject.FindGameObjectWithTag ("Level1") != null) {
			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			//print (player.transform.parent.tag == "Level1");
			if (player.transform.parent != null) {
				if (player.transform.parent.tag == "Level1") {
					if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Level2Transition").transform.position, player.transform.position) < 2.1f) {
						print ("Congratulations you are in lvl 2!");

						levelActivationAuthority.GetComponent<LevelActivationScript> ().ReactivateLevelsExceptFor ("");
						GameObject.FindGameObjectWithTag ("Level1").SetActive (false);
						GameObject.FindGameObjectWithTag ("Level3").SetActive (false);


						GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().orthographicSize = 5f;


					}
				}
			}
			if (GameObject.FindGameObjectWithTag ("Level2Ninja") != null) {
				//print (Vector3.Distance (GameObject.FindGameObjectWithTag ("Level3Transition").transform.position, player.transform.position));
				if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Level3Transition").transform.position, player.transform.position) < 2.8f) {
					print ("Congratulations you are in lvl 3!");

					levelActivationAuthority.GetComponent<LevelActivationScript> ().ReactivateLevelsExceptFor ("Level2");
					//Debug.Log ("Level2 authorized?" + GameObject.FindGameObjectWithTag ("Level2") != null);
					//Debug.Log ("Level3 authorized?" + GameObject.FindGameObjectWithTag ("Level1") != null);
					if (GameObject.FindGameObjectWithTag ("Level2") != null) {
						GameObject.FindGameObjectWithTag ("Level2").SetActive (false);
					}
					if (GameObject.FindGameObjectWithTag ("Level1") != null) {
						GameObject.FindGameObjectWithTag ("Level1").SetActive (false);
					}


				}
			}
			if (player.transform.parent != null) {
				if (player.transform.parent.tag == "Level1") {
					//lEVEL 1 IS WORKING
					//print("level1 is working");
					if (player.GetComponent<Ninja> ().livesRemaining == 2) {
						//print (true);
						Destroy (listOfHearts [2]);
						//print (player.GetComponent<Ninja> ().m.Length);

						//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ());
						if (player.GetComponent<Ninja> () != null) {
				
							player.GetComponent<Ninja> ().invincible = true;

							//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible);

							Coroutine co;

							co = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable1 ());

							if (player.GetComponent<Ninja> ().invulnerableTimer > 100) {
								StopCoroutine (co);
								GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible = false;
							}
						}
					}
					if (player.GetComponent<Ninja> ().livesRemaining == 1) {
						Destroy (listOfHearts [1]);

						player.GetComponent<Ninja> ().invincible = true;
						Coroutine co1;

						co1 = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable2 ());

						if (player.GetComponent<Ninja> ().secondInvulnerableTimer > 100) {
							StopCoroutine (co1);
							player.GetComponent<Ninja> ().invincible = false;
						}
					}
					if (player.GetComponent<Ninja> ().livesRemaining == 0) {
						Destroy (listOfHearts [0]);
					}
				}
			}

			//if (player.transform.parent.tag == "Level2") {
			if (GameObject.FindGameObjectWithTag ("Level2Ninja") != null) {
				if (player.transform.parent.tag == "Level2") {
					//print ("Level2 is working");
					if (player.GetComponent<Ninja> ().livesRemaining == 2) {
						//print ("2 lives remaining");
						Destroy (listOfHearts [2]);
						//print (player.GetComponent<Ninja> ().m.Length);

						//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ());

						if (player.GetComponent<Ninja> () != null) {
							//print ("not null");

							player.GetComponent<Ninja> ().invincible = true;

							//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible);

							Coroutine co;

							co = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable1 ());

							if (player.GetComponent<Ninja> ().invulnerableTimer > 100) {
								StopCoroutine (co);
								GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible = false;
							}
						}
					}
					if (player.GetComponent<Ninja> ().livesRemaining == 1) {
						Destroy (listOfHearts [1]);

						player.GetComponent<Ninja> ().invincible = true;
						Coroutine co1;

						co1 = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable2 ());

						if (player.GetComponent<Ninja> ().secondInvulnerableTimer > 100) {
							StopCoroutine (co1);
							player.GetComponent<Ninja> ().invincible = false;
						}
					}
					if (player.GetComponent<Ninja> ().livesRemaining == 0) {
						Destroy (listOfHearts [0]);
					}
				}
			}
			if (GameObject.FindGameObjectWithTag ("Level3Ninja") != null) {
				if (GameObject.FindGameObjectWithTag ("Level2") != null) {
					GameObject.FindGameObjectWithTag ("Level2").SetActive (false);
				}
				if (GameObject.FindGameObjectWithTag ("Level1") != null) {
					GameObject.FindGameObjectWithTag ("Level1").SetActive (false);
				}

				if (player.transform.parent != null) {
					if (player.transform.parent.tag == "Level3") {
						//print ("LEVEL 3 is Working");
						//print (Vector3.Distance (GameObject.FindGameObjectWithTag ("Level2Transition").transform.position, player.transform.position));
						if (player.GetComponent<Ninja> () != null) {
							if (player.GetComponent<Ninja> ().livesRemaining == 2) {
								//print (true);
								Destroy (listOfHearts [2]);
								//print (player.GetComponent<Ninja> ().m.Length);

								//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ());
								if (player.GetComponent<Ninja> () != null) {

									player.GetComponent<Ninja> ().invincible = true;

									//print (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible);

									Coroutine co;

									co = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable1 ());

									if (player.GetComponent<Ninja> ().invulnerableTimer > 100) {
										StopCoroutine (co);
										GameObject.FindGameObjectWithTag ("Player").GetComponent<Ninja> ().invincible = false;
									}
								}
							}
							if (player.GetComponent<Ninja> ().livesRemaining == 1) {
								Destroy (listOfHearts [1]);

								player.GetComponent<Ninja> ().invincible = true;
								Coroutine co1;

								co1 = StartCoroutine (player.GetComponent<Ninja> ().Invulnerable2 ());

								if (player.GetComponent<Ninja> ().secondInvulnerableTimer > 100) {
									StopCoroutine (co1);
									player.GetComponent<Ninja> ().invincible = false;
								}
							}
							if (player.GetComponent<Ninja> ().livesRemaining == 0) {
								Destroy (listOfHearts [0]);
							}
						}
					}
				}


			}
		}
		//}
	}
}
