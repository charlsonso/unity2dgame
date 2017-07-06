using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingEnemy : MonoBehaviour {
	private Rigidbody2D rb2d;
	public  bool rise;
	public float timer = 1f;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rise) {
			rb2d.gravityScale = 0;
			rb2d.position = rb2d.position + (Vector2.up * 0.1f);
		} else
			rb2d.gravityScale = 5;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "HeightCheck") {
			StartCoroutine (enemyShake (3));
			rise = false;
		} else if (col.tag == "Ground") {
			StartCoroutine (groundWait (2));
		}
	}

	IEnumerator enemyShake(float fallTime){
		Vector2 originalPos = rb2d.position;
		rb2d.isKinematic = true;
		while (fallTime > 0) {
			rb2d.position = new Vector2(originalPos.x, rb2d.position.y + (Random.insideUnitCircle.y*0.01f));
			rb2d.position = originalPos;
			yield return new WaitForSeconds(0.001f);
			fallTime -= Time.deltaTime;

		}
			rb2d.isKinematic = false;

	}
	
	IEnumerator groundWait(float waitTime){
		rise = false;
		Debug.Log("ground check working");
		while (waitTime > 0) {
			yield return new WaitForSeconds (0.001f);
			waitTime -= Time.deltaTime;
		}
		rise = true;
	}

}
