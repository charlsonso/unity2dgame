using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // float x = Input.GetAxis("Horizontial") * moveSpeed;
        //float y = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(Vector2.right * moveSpeed );
	}
}
