using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {
    public float Xforce;
    public float Yforce;
    public float damage;
    public string target; //what the target is
    public float distance;
    public float life;
   // private float howfar; unused dist var
    private GameObject player; 
    public Sprite onDeath; //pick death sprite
    Rigidbody2D charRigidBody; 
    SpriteRenderer sr;  //access sprite renderer
    //allows us to maniuplate speed

    // Use this for initialization
    void Start () {
        player = GameObject.Find(target);
        charRigidBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject == player)
        {
            sr.sprite = onDeath;
            Destroy(gameObject,.3f);
        }
    }

    // Update is called once per frame

    void Update () {
       //distance to player
       // howfar = Vector2.Distance(this.transform.position,player.transform.position);
        // print("The variable is :" + howfar);

        //if under distance, apply force
        //if (howfar < distance)
        //{
            charRigidBody.AddForce(new Vector2(Xforce,Yforce ), ForceMode2D.Impulse);
        //}
        Destroy(gameObject,2);
        
    }

}

