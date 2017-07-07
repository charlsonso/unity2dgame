using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int enemyHP;
    public GameObject deathEffect;
    public int pointsOnDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHP <= 0)
        {
            if (gameObject != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
               // if(transform.parent.gameObject != null) //if the gameobject is a child; it will destroy the parent as well
               // {
                //    Destroy(transform.parent.gameObject);
               // }
            }
        }
	}
    public void giveDamage(int damageToGive)
    {
        enemyHP -= damageToGive;
    }
}
