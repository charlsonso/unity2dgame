using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour {
	//camera must match transform of the character, camera is following
	public Transform target;
	//dampening effect on the camera
	public float smoothing;
	//difference between the character and camera
	Vector3 offset;
	//lowest point our camera can go
	float lowY;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		//core position of the camera
		lowY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		//where does the camera want to be
		Vector3 targetCamPos = target.position + offset;
		//lerp lets us switch from one position to the next
		//lerp will slow down based off smoothing
		//Time.deltaTime is the difference between the last frame
		//ctrl+' for help on functions
		transform.position = Vector3.Lerp(transform.position,targetCamPos, smoothing*Time.deltaTime);

		//don't follow if character is falling out map
		if(transform.position.y<lowY) 
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
	}


}
