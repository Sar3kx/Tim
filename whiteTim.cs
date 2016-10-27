using UnityEngine;
using System.Collections;

public class whiteTim : MonoBehaviour {

	//floats
	public float moveSpeed;
	private float ball_xvel, ball_yvel;
	float moveVelocity;

	private Vector2 movement;
	public LayerMask playerLayerMask;


	//Booleans
	public bool IsDead;
	public bool isGrounded;



	//Otherscripts
	public SmoothCamera2D cam;



	//Gameobjects
	public GameObject Shatter;
	private GameObject PlayerTim;


	//AudioClips
	//public AudioClip BallHIT;


	//Transforms
	private Transform myTrans;
	public Transform tagGround,tagGround1,tagGround2,tagGround3,tagGround4 ;


	//Rigidbody2D
	private Rigidbody2D myBody;

    //animator
    public Animator PlayerDiedPanal;



    void Start ()
    {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		PlayerTim = this.gameObject;

	}
	
	
	void Update ()
    {
		isGrounded = 
		Physics2D.Linecast (myTrans.position, tagGround.transform.position, playerLayerMask) ||
		Physics2D.Linecast (myTrans.position, tagGround1.transform.position, playerLayerMask) ||
		Physics2D.Linecast (myTrans.position, tagGround2.transform.position, playerLayerMask) ||
		Physics2D.Linecast (myTrans.position, tagGround3.transform.position, playerLayerMask) ||
		Physics2D.Linecast (myTrans.position, tagGround4.transform.position, playerLayerMask); 
		//	Debug.DrawLine (myTrans.position,tagGround.transform.position,Color.red);



		moveVelocity = 0;
		//Input 
		if (Input.GetKey (KeyCode.Mouse0))
        {	
			moveVelocity = moveSpeed;
		}
		if (Input.GetKey (KeyCode.Mouse1))
        { 	
			moveVelocity = -moveSpeed;
		}


		myBody.velocity = new Vector2 (moveVelocity, myBody.velocity.y);
			if (isGrounded)
        {
   			ball_yvel = 16;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(ball_xvel, ball_yvel);
            
        }

		if (IsDead == true)
        {
			PlayerTim.SetActive (false);
			cam.shakeCamera (0.1f, 1);
			Instantiate(Shatter, PlayerTim.transform.position, Quaternion.Euler(0, 180, 0));
            PlayerDiedPanal.SetTrigger("PlayerdiedPanalHIT");
		}
	}
	

	//Collision Enter 
	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "BlackGround")
		{
			IsDead = true;
		}
		if (col.gameObject.tag == "Enemy") {
			IsDead = true;
		}


		
	}

	//Collision Exit
	public void OnCollisionExit2D(Collision2D col)
    {
		//isGrounded = false;
	}


	//Trigger Enter 
	public void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.gameObject.tag == "TempSupporter")
        { 
			Other.gameObject.SetActive (false);
			cam.shakeCamera (0.1f, 10f);
		}

        if (Other.gameObject.tag == "BlackGround")
        {
            IsDead = true;
        }
        if (Other.gameObject.tag == "Enemy")
        {
            IsDead = true;
        }

    }

	public void OnTriggerExit2D(Collider2D Other)
    {




	}
    
}
