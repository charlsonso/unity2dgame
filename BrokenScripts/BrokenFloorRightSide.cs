using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloorRightSide : MonoBehaviour
{
    private playerController player1;
    private zombieMovementController enemy1;
    //Object of the broken floor rigidbody 
    Rigidbody2D bRFloor;

    // Use this for initialization
    void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        enemy1 = gameObject.GetComponentInChildren<zombieMovementController>();
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
        StartCoroutine(player1.KnockbackRight(0.3f, 15, player1.transform.position));
    }
    // 

    private void OnCollison2D(Collider2D collision1)
    {
        if (collision1.CompareTag("Enemy"))
        {
            
        }

    }

}
