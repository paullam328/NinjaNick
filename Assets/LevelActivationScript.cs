using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActivationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReactivateLevelsExceptFor(string tag) {
		foreach (Transform child in this.transform)
		{
			if (child.tag != tag || tag == "") {
				child.gameObject.SetActive (true);
			} else {
				child.gameObject.SetActive (false);
			}
		}
	}
}
