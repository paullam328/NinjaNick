using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject level1Player;
	public GameObject level2Player;
	public GameObject level3Player;

	public GameObject[] pixelHearts;

	// Use this for initialization
	void Start () {
		this.GetComponent<Camera> ().orthographicSize = 2;
		this.GetComponent<Camera> ().transform.position = new Vector3 (35.6f, -16.6f, -10);
		pixelHearts = GameObject.FindGameObjectsWithTag ("PixelHeart");
		for (int i = 0; i < pixelHearts.Length; i++) {
			pixelHearts [i].transform.localScale = new Vector3 (0.05f, 0.05f, 1);
		}
		pixelHearts [0].transform.localPosition = new Vector3 (-2.32f-1, 1.65f, 5);
		pixelHearts [1].transform.localPosition = new Vector3 (-1.86f-1, 1.65f, 5);
		pixelHearts [2].transform.localPosition = new Vector3 (-1.4f-1, 1.65f, 5);


		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Level1") != null) {
			if (GameObject.FindGameObjectWithTag ("Level1").activeSelf) {
				this.transform.position = new Vector3 (level1Player.transform.position.x + 2,
					level1Player.transform.position.y + 1,
					this.transform.position.z);
			}
		}
		if (GameObject.FindGameObjectWithTag ("Level2Ninja") != null) {
				//print ("not null");
				//print (level2Player.transform.position.x);
				this.transform.position = new Vector3 (GameObject.FindGameObjectWithTag ("Level2Ninja").transform.position.x+6,
					GameObject.FindGameObjectWithTag ("Level2Ninja").transform.position.y+2,
					this.transform.position.z);

			pixelHearts = GameObject.FindGameObjectsWithTag ("PixelHeart");

			for (int i = 0; i < pixelHearts.Length; i++) {
				pixelHearts[i].transform.localScale = new Vector3 (0.10f, 0.10f, 1);
			}
			pixelHearts [0].transform.localPosition = new Vector3 (-8.25f, 3.75f, 5);
			pixelHearts [1].transform.localPosition = new Vector3 (-7.25f, 3.75f, 5);
			pixelHearts [2].transform.localPosition = new Vector3 (-6.25f, 3.75f, 5);

			}

		if (GameObject.FindGameObjectWithTag ("Level3Ninja") != null) {
			//print ("level3 not null");
			//print (level3Player.transform.position.x);
			//GameObject.FindGameObjectWithTag("Level2").SetActive(false);
			this.transform.position = new Vector3 (GameObject.FindGameObjectWithTag ("Level3Ninja").transform.position.x+2.5f,
				GameObject.FindGameObjectWithTag ("Level3Ninja").transform.position.y + 1,
				this.transform.position.z);

			this.GetComponent<Camera> ().orthographicSize = 2f;

			if (GameObject.FindGameObjectWithTag ("Level2Ninja") != null) {
				GameObject.FindGameObjectWithTag ("Level2Ninja").transform.parent.gameObject.SetActive (false);
			}
			if (GameObject.FindGameObjectWithTag ("Level1Ninja") != null) {
				GameObject.FindGameObjectWithTag ("Level1Ninja").transform.parent.gameObject.SetActive (false);
			}

			pixelHearts = GameObject.FindGameObjectsWithTag ("PixelHeart");
			for (int i = 0; i < pixelHearts.Length; i++) {
				if (pixelHearts [i] != null) {
					pixelHearts [i].transform.localScale = new Vector3 (0.05f, 0.05f, 1);
				}
			}
			if (pixelHearts [0] != null) {
				pixelHearts [0].transform.localPosition = new Vector3 (-3.25f, 1.75f, 5);
			}
			if (pixelHearts [1] != null) {
				pixelHearts [1].transform.localPosition = new Vector3 (-2.75f, 1.75f, 5);
			}
			if (pixelHearts [2] != null) {
				pixelHearts [2].transform.localPosition = new Vector3 (-2.25f, 1.75f, 5);
			}

		}

	}
}
