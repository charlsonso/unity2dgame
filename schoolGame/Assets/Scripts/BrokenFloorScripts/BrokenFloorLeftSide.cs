using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorLeftSide : MonoBehaviour
{
    private playerController player1;
    private zombieMovementController enemy1;
    //Object of the broken floor rigidbody 
    Rigidbody2D bLFloor;
    private Rigidbody2D playerRB;

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
            Debug.Log("left");

            StartCoroutine(KnockbackLeft(0.1f, 0f, player1.transform.position));
        }
    }
    // 

    private void OnCollison2D(Collider2D collision1)
    {
        if (collision1.CompareTag("Enemy"))
        {

        }

    }

    //Left Knockback Function
    public IEnumerator KnockbackLeft(float knockbackDuration, float knockbackPower, Vector3 knockbackDirection)
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
            Debug.Log(playerRB.position.x);
            if (playerRB.position.x <= 0f) playerRB.AddForce(new Vector3(knockbackDirection.x * 30, knockbackDirection.y * knockbackPower, transform.position.z));
            else if (playerRB.position.x >= 0f) playerRB.AddForce(new Vector3(knockbackDirection.x * -30, knockbackDirection.y * knockbackPower, transform.position.z));
        }
        //returns the knockback force
        yield return 0;

    }
}
