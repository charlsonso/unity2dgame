using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int enemyHP;
    public Sprite deathEffect;
    public int pointsOnDeath;
    SpriteRenderer sr;  //access sprite renderer
                        // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(enemyHP <= 0)
        {
           if (gameObject != null)
          {
                sr.sprite = deathEffect;
                Destroy(gameObject, 1);
            }
        }
	}
    public void giveDamage(int damageToGive)
    {
        enemyHP -= damageToGive;
    }
}
