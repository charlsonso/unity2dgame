using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorTopScript : MonoBehaviour
{
    //Object creat of player
    private playerController player1;
    private zombieMovementController enemy1;
    private Rigidbody2D playerRB;
    //Object of the broken floor rigidbody 
    Rigidbody2D bFloor;

    // Use this for initialization
    void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        playerRB = GameObject.Find("mainCharacter").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Collision on Trigger with the broken floor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the condition of a collsion occuring with
        //the tag player the player takes damage of 1
        if (collision.CompareTag("Player"))
        {
            player1.Damage(1);

            //Takes the values for the knockback fucntion to
            //the player object
            Debug.Log("top");
            StartCoroutine(Knockback(1f, .5f, player1.transform.position));
        }
    }

    //Flip enemy on collison with broken floor 
    private void OnCollison12D(Collider2D collision1)
    {
        if (collision1.CompareTag("Enemy"))
        {

        }

    }
    //Top Knockback Function
    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Vector3 knockbackDirection)
    {

        //current time
        float timer = 0;

        //while loop with the conditon where the 
        //IEnumator is used
        while (knockbackDuration > timer)
        {

            //increments the time
            timer += Time.deltaTime;

            //RigidBody is knocked back using a force in a x and y direction
            //z is not changed
            playerRB.velocity = new Vector2(playerRB.velocity.x, 15);

            //myRB.AddForce(new Vector3(/*knockbackDirection.x * -100*/ 0*myRB.position.x,
            //   /*knockbackDirection.y * knockbackPower*/ 1.5f * myRB.position.y, transform.position.z));

        }

        //returns the knockback force
        yield return 0;

    }
}
