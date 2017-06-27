using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	//movement variables
	public float maxSpeed;
    public float jumpHeight;
    //dectect ground
     bool canJump;
	//reference to rigid body, changing velocity, etc...
	Rigidbody2D charRigidBody;
	//allows us to maniuplate speed
	Animator anim;
	bool facingRight;

	// Use this for initialization
	void Start () {
		charRigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		facingRight = true;
       
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        float jump = Input.GetAxis("Vertical");
        // If the Collider2D component is enabled on the collided object
        if (coll.collider == true)
        {
          
            canJump = true;
            print(canJump);

        }
    


    }

    void OnCollisionExit2D(Collision2D coll)
    {

        //if (coll.collider == false)
        {
            canJump = false;
            print(canJump);
        }
    }

        // Update is called once per frame
        //changed to fixedupdate
        //called after a specific amount of time, all the time
        //too get physics objects properly you want to manipulate in fixedupdate
        void FixedUpdate () {
		//get axis returns value between -1 and 1
		//getaxis raw will only return -1 0 and 1
		float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
		anim.SetFloat ("speed", Mathf.Abs(move));
		charRigidBody.velocity = new Vector2(move * maxSpeed, anim.velocity.y);
     

        if(canJump==true)
        {

            charRigidBody.AddForce(new Vector2(anim.velocity.x, jump * jumpHeight), ForceMode2D.Force);
        }

      
		//need to switch based off if moving right but not facing right
		if (move > 0 && !facingRight) {
			flip();
		} 
		else if (move < 0 && facingRight) {
			flip();
		}
			
	}

	void flip(){
		//need to change the transform scale to negative
		//switch between if its facing right
		//
		facingRight = !facingRight;
		//creat
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
