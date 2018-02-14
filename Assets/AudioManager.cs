using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip prebossMusic;
	public AudioClip finalbossMusic;

	public GameObject integratedBoss;
	private AudioSource audioSource;

	public int playOnceCounter;
	// Use this for initialization
	void Start () {
		audioSource = this.GetComponent<AudioSource> ();
		audioSource.clip = prebossMusic;
		audioSource.Play ();

		playOnceCounter = 0;


	}

	// Update is called once per frame
	void Update () {
		if (playOnceCounter < 1 && integratedBoss.GetComponent<IntegratedBossController> ().isDroppingDown) {
			audioSource.Stop ();
			audioSource.clip = finalbossMusic;
			audioSource.Play ();

			playOnceCounter++;
		}
		
	}
}
