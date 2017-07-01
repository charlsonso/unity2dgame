using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {
    public int damageToGive;
    public float bounce;
    private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        playerRB = transform.parent.GetComponent<Rigidbody2D>(); //get rigidbody of player


    }
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            playerRB.velocity = new Vector2(playerRB.velocity.x, bounce);
        }
    }
}
