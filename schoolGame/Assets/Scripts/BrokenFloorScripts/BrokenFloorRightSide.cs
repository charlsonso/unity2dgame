using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorRightSide : MonoBehaviour
{
    private playerController player1;
    //private zombieMovementController enemy1;
    //Object of the broken floor rigidbody 
    Rigidbody2D bRFloor;
    private Rigidbody2D playerRB;

    // Use this for initialization
    void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        //  enemy1 = gameObject.GetComponentInChildren<zombieMovementController>();
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
            Debug.Log("Rght");
            StartCoroutine(KnockbackRight(0.1f, .1f, player1.transform.position));
        }
    }
    // 

    private void OnCollison2D(Collider2D collision1)
    {
        if (collision1.CompareTag("Enemy"))
        {
            
        }

    }
    //Right Knockback Function
    public IEnumerator KnockbackRight(float knockbackDuration, float knockbackPower, Vector3 knockbackDirection)
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
            //fix 
            Debug.Log(playerRB.position.x + " right");

            if (playerRB.position.x <= 0f) playerRB.AddForce(new Vector3(knockbackDirection.x * -30, knockbackDirection.y * knockbackPower, transform.position.z));
            if (playerRB.position.x >= 0f) playerRB.AddForce(new Vector3(knockbackDirection.x * -30, knockbackDirection.y * knockbackPower, transform.position.z));

        }

        //returns the knockback force
        yield return 0;

    }
}
