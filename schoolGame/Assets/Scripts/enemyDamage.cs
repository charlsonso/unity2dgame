using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {
	public float damage;
	//how often enemy can do damage
	public float damageRate;
	public float pushBackForce;
	//fallingEnemy fE;
	//when damage occurs next
	float nextDamage;
	// Use this for initialization
	void Start () {
		//character can be damaged immediately
		nextDamage = 0f;
		//fE = GetComponent<fallingEnemy> ();

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other){
		//damage character if rate allows it and character collides
		if (other.tag == "Player" && nextDamage < Time.time) {
			mainCharacterHealth health=other.gameObject.GetComponent<mainCharacterHealth>();
			health.removeHealth (damage);
			nextDamage = Time.time + damageRate;


			pushBack (other.transform);

		}
	}

	//push the character straight up
	void pushBack(Transform pushObject){
		Vector2 pushDirection = new Vector2 (0, (pushObject.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}