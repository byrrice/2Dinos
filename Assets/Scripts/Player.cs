// Based on https://stackoverflow.com/questions/42207122/create-a-basic-2d-platformer-game-in-unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 5f;
	bool isGrounded = false;
    Rigidbody2D rb;
    Vector3 startingPosition; 
	[HideInInspector] public bool facingRight = true;
	Animator MyAnimator;

    void Start()
    {
		MyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        startingPosition = transform.position;
    }


    void Update()
    {
        var input = Input.GetAxis("Horizontal"); 
        var movement = input * speed;
		MyAnimator.SetFloat("Speed", Mathf.Abs(movement));
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

		if (input > 0 && !facingRight)
			Flip();
		else if (input < 0 && facingRight)
			Flip();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
			MyAnimator.SetBool("Ground", false);
            rb.AddForce(new Vector3(0, 300, 0)); // Adds 300 force straight up, might need tweaking on that number
        }
    }
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Entered");
		if (collision.gameObject.CompareTag("Ground"))
		{
			MyAnimator.SetBool("Ground", true);
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("Exited");
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}	
// public class Player : MonoBehaviour {

// 	[HideInInspector] public bool facingRight = true;
// 	[HideInInspector] public bool jump = true;
// 	public float moveForce = 365f;
// 	public float maxSpeed = 5f; 
// 	public float jumpForce = 1000;
// 	public Transform groundCheck;

// 	private bool grounded = false;
// 	private Animator anim;
// 	private Rigidbody2D rb2d;


// 	// Use this for initialization
// 	void Awake () {
// 		anim = GetComponent<Animator>();
// 		rb2d = GetComponent<Rigidbody2D>();
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
// 		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLlayer("Ground"));

// 		if (Input.GetButtonDown("Jump") && grounded)
// 		{
// 			jump = true;
// 		}
// 	}

// 	void FixedUpdate(){
// 		float h = Input.GetAxis("Horizontal");
// 		anim.SetFloat("Speed", Mathf.Abs(h));

// 		if (h * rb2d.velocity.x < maxSpeed)
// 			rb2d.AddForce(Vector2.right * h * moveForce);
// 		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
// 			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		
// 		if (h > 0 && !facingRight)
// 			Flip();
// 		else if (h < 0 && facingRight)
// 			Flip();

// 		if (jump){
// 			anim.setTrigger("Jump");
// 			rb2d.AddForce(new Vector2(0f, jumpForce));
// 			jump = false;
// 		}
// 	}

// 	void Flip(){
// 		facingRight = !facingRight;
// 		Vector3 theScale = transform.localScale;
// 		theScale.x *= -1;
// 		transform.localScale = theScale;
// 	}
// }
}
