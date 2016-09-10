using UnityEngine;
using System.Collections;

public class whiteTim : MonoBehaviour {

	//floats

	public float moveSpeed;
	public float ball_xvel, ball_yvel;

	private Vector2 movement;

	public LayerMask playerLayerMask;


	//Booleans
	private bool IsDead;
	public bool isGrounded;



	//Animators
	public Animator WhiteGroundShake;


	//Otherscripts
	public SmoothCamera2D cam;
	public Buttons Button;


	//Gameobjects
	public GameObject Shatter;
	private GameObject PlayerTim;


	//AudioClips
	public AudioClip BallHIT;


	//Transforms
	private Transform myTrans;
	public Transform tagGround,tagGround1,tagGround2,tagGround3,tagGround4 ;


	//Rigidbody2D
	private Rigidbody2D myBody;


	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		PlayerTim = this.gameObject;
		//tagGround = GameObject.Find(this.name +"/tag_Ground).transform;


	
	}
	
	// Update is called once per frame
	void Update () {
		
		isGrounded = 
			Physics2D.Linecast (myTrans.position, tagGround.transform.position, playerLayerMask) || 
			Physics2D.Linecast (myTrans.position, tagGround1.transform.position, playerLayerMask) || 
			Physics2D.Linecast (myTrans.position, tagGround2.transform.position, playerLayerMask) || 
			Physics2D.Linecast (myTrans.position, tagGround3.transform.position, playerLayerMask) ||
			Physics2D.Linecast (myTrans.position, tagGround4.transform.position, playerLayerMask) ;  
		/*	Debug.DrawLine (myTrans.position,GameObject.Find(this.name+"/tag_ground3").transform.position,Color.red);
			Debug.DrawLine (myTrans.position,GameObject.Find(this.name+"/tag_ground4").transform.position,Color.red);
			ebug.DrawLine (myTrans.position,GameObject.Find(this.name+"/tag_ground2").transform.position,Color.red);*/




		//Input 
		if (Input.GetKey  (KeyCode.Mouse0)) {
			myBody.velocity = transform.right * moveSpeed;
			//transform.Translate (Vector2.right * moveSpeed * Time.fixedTime);
			//transform.Translate(transform.right * moveSpeed* Time.smoothDeltaTime );
		}

		if (Input.GetKey   (KeyCode.Mouse1)) {
			//myBody.AddForce (-Vector2.right * moveSpeed * Time.deltaTime);
			//transform.Translate(-transform.right * moveSpeed* Time.smoothDeltaTime );
		}
		if (isGrounded) {
			
			ball_yvel = 10;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, ball_yvel);
			//myBody.velocity += jumpForce * Vector2.up * Time.deltaTime;

		}
	}








	//Collision Enter 
	public void OnCollisionEnter2D(Collision2D col)
	{

		//isGrounded = true;
		if (col.gameObject.tag == "BlackGround")
		{
			IsDead = true;
			//Destroy(gameObject);
			PlayerTim.SetActive (false);
			cam.shakeCamera(0.1f, 1);
			//  Instantiate(playerDeadPartical, PlayerTim.transform.position, Quaternion.Euler(0, 180, 0));
		}

		if (col.gameObject.tag == "whiteShakingGround")
		{
			WhiteGroundShake.SetTrigger("PlayerHIT");

		}
	}

	//Collision Exit
	public void OnCollisionExit2D(Collision2D col){
		//isGrounded = false;
	}


	//Trigger Enter 
	public void OnTriggerEnter2D(Collider2D Other)
	{




	}




}
