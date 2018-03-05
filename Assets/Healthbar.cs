using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public Image currentHealthbar;
	public Text ratioText;

	private float hitpoint;
	private float maxHitpoint = 1200;

	public bool showHealthbar;
	//public GameObject boss;

	// Use this for initialization
	void Start () {
		showHealthbar = false;
		//UpdateHealthbar ();
	}

	void Update() {
		hitpoint = this.GetComponent<IntegratedBossController>().healthRemaining;
		UpdateHealthbar ();
	}
	
	// Update is called once per frame
	void UpdateHealthbar () {
		float ratio = hitpoint / maxHitpoint;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		//ratioText.text = (ratio * 100).ToString () + "%";
		ratioText.text = "CAPTAIN MORGAN";
	}

}
