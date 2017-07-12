using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_spawner : MonoBehaviour {
    private float howfar;
    public float distance;
    public string target;
    private GameObject player;
    public GameObject projectile; 
    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchProjectile", .5f, 1f);
        player = GameObject.Find(target);
       // charRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        howfar = Vector2.Distance(this.transform.position, player.transform.position);
        // print("The variable is :" + howfar);

        //if under distance, apply force
        if (howfar < distance)
        {
           
        }
    }

    void LaunchProjectile()
    {
        if (howfar < distance)
        {
            Instantiate(projectile, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}
