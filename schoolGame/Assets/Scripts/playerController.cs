using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;
    bool facingRight = true;
    Rigidbody2D myRB;
    Animator myAnimator;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnimator.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }
    // Update is called once per frame
    // always exactly the same time that it is called.
    //RigidBody means that the object is now affected by physics.
    // --> Update is called on every single frame doesnt consider frames
    // --> FixedUpdate is always called on a specific amount of time.
    void FixedUpdate()
    {

        //check if grounded? is it intersecting the ground = true else false
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //draw a tiny circle that checks param
        myAnimator.SetBool("isGrounded", grounded);

        myAnimator.SetFloat("verticalSpeed", myRB.velocity.y);
        float move = Input.GetAxis("Horizontal");
        myAnimator.SetFloat("speed", Mathf.Abs(move)); //param and give it the value

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); // manipulate x value
                                                                       // y value is not changed
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip(); //pressing a and facing left
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale; // take values and place in scale
        scale.x *= -1;
        transform.localScale = scale;
    }
}
