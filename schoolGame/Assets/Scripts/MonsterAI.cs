using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {
    public float Xforce;
    public float Yforce;
    public float damage;
    public string target;
    public float distance;
    public float life;
    private float howfar;
    private GameObject player;

    Rigidbody2D charRigidBody;
    //allows us to maniuplate speed
  
    // Use this for initialization
    void Start () {
        player = GameObject.Find(target);
        charRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

	void Update () {
       //distance to player
        howfar = Vector2.Distance(this.transform.position,player.transform.position);
        // print("The variable is :" + howfar);

        //if under distance, apply force
        if (howfar < distance)
        {
            charRigidBody.AddForce(new Vector2(Xforce,Yforce ), ForceMode2D.Impulse);
        }
    }

}

