using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterHealth : MonoBehaviour {
	public float maxHealth;
	float currentHealth;
	playerController controlMovement;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		controlMovement = GetComponent<playerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//remove health
	public void removeHealth(float damage){
		//enemies can do no damage but affect character
		if (damage <= 0) {
			return;
		}
		currentHealth -= damage;
		//kill character if no more health
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	//kill character, possible to kill character instantly with this function
	public void makeDead(){
		Destroy (gameObject);	
	}
}
