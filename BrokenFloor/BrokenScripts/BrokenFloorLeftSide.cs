using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorLeftSide : MonoBehaviour
{
    private playerController player1;
    private zombieMovementController enemy1;
    //Object of the broken floor rigidbody 
    Rigidbody2D bLFloor;

    // Use this for initialization
    void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();

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
            player1.Damage(1);

        //Takes the values for the knockback fucntion to
        //the player object
        StartCoroutine(player1.KnockbackLeft(0.1f, 1, player1.transform.position));
    }
    // 

    private void OnCollison2D(Collider2D collision1)
    {
        if (collision1.CompareTag("Enemy"))
        {

        }

    }
}
