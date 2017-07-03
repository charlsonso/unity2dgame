using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour {
    public float platformFallTime;
    public float movementSpeedX;
    public float movementSpeedY;
    public bool reversed;
    public float maxDist;
   
    private Vector2 start;
    private Vector2 dist;
	// Use this for initialization
	void Start () {
        reversed = false;
        start = new Vector2(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
        if (reversed == false)
        {
            transform.Translate(movementSpeedX / 10, movementSpeedY / 10,0);
        }
        else
        {
            transform.Translate(-1*(movementSpeedX / 10), -1 * (movementSpeedY / 10),0);
        }
        dist = new Vector2(transform.position.x, transform.position.y);
        
        if(Vector2.Distance(start,dist)> maxDist)
        {

            if(reversed ==false)
            { reversed = true; }
            else
            {
                reversed = false;
            }
        }
	}

   
}
