using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1and3Ninja : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	public int health;

	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	bool facingRight = true; 


	public Object fireball;
	public int shootingSpeed;
	public int livesRemaining;

	public int invulnerableTimer;
	public int secondInvulnerableTimer;

    public float airTimer;

    public Material[] m;

	public bool invincible;


	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		livesRemaining = 3;
		invulnerableTimer = 0;
        airTimer = 0.0f;
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Update anim Speed parameter for animation
		anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, 0);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);

		if (moveHorizontal > 0 && !facingRight)
			Flip ();
		else if (moveHorizontal < 0 && facingRight)
			Flip ();

		if (livesRemaining == 0) {
			Die ();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {  //makes player jump
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,8), ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			Shoot ();
		}

        if (!grounded) {
            airTimer += Time.deltaTime * 10;
            if (airTimer > 30.0f) {
                Die();
            }
            print("========================" + airTimer + "=========================");
        } else {
            airTimer = 0.0f;
        }
    } 

	void Shoot() {
		//while (this.transform.parent != null) {
		if (this.transform.parent != null) {
			if (this.transform.parent.tag == "Level1") {
				if (facingRight) {
					GameObject newarrow = (GameObject)Instantiate (fireball, new Vector3 (this.transform.position.x + 0.15f, this.transform.position.y - 0.08f, this.transform.position.z), new Quaternion (0, 0, 0, 0));
					newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
				} else {
					GameObject newarrow = (GameObject)Instantiate (fireball, new Vector3 (this.transform.position.x - 0.15f, this.transform.position.y - 0.08f, this.transform.position.z), Quaternion.Euler(new Vector3(0,180,0)));
					newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);		
				}
			} else {
				if (facingRight) {
					GameObject newarrow = (GameObject)Instantiate (fireball, new Vector3 (this.transform.position.x + 0.75f, this.transform.position.y - 0.08f, this.transform.position.z), new Quaternion (0, 0, 0, 0));
					newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootingSpeed, 0);
				} else {
					GameObject newarrow = (GameObject)Instantiate (fireball, new Vector3 (this.transform.position.x - 0.75f, this.transform.position.y - 0.08f, this.transform.position.z), Quaternion.Euler(new Vector3(0,180,0)));
					newarrow.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-shootingSpeed, 0);		
				}
				//}
			}
		}
	}

	void Die() {
        Debug.Log("character has died123");
        //RestartMenu.restartMenuUI.SetActive(true);
        DontDestroyOnLoad(transform.root.gameObject);
        print("========================================= menu loaded");
        SceneManager.LoadScene("menu");

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("MainMenu");
        foreach (GameObject go in gameObjectArray) {
            print("testing");
            go.SetActive(false);
        }

        GameObject[] gameObjectArray1 = GameObject.FindGameObjectsWithTag("RestartMenu");
        foreach (GameObject go in gameObjectArray1) {
            print("testing");
            go.SetActive(true);
        }

        DestroyObject(transform.root.gameObject);
    }

	public IEnumerator Invulnerable1() {
		//while (invulnerableTimer < 1000) {
		gameObject.GetComponent<SpriteRenderer> ().material = m [0];
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<SpriteRenderer> ().material = m [1];
		invulnerableTimer++;//break doesn't work
		//}
	}

	public IEnumerator Invulnerable2() {
		//while (invulnerableTimer < 1000) {
		gameObject.GetComponent<SpriteRenderer> ().material = m [0];
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<SpriteRenderer> ().material = m [1];
		secondInvulnerableTimer++;//break doesn't work
		//}
	}

}
