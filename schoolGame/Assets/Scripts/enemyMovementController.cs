using UnityEngine;

public class enemyMovementController : MonoBehaviour {

    //Animations
    public float enemySpeed;
    Animator enemyAnimator;

    //Enemy transformations
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false; //starts off looking left
    float flipTime = 5f; //possiblity that the boar can flip
    float nextFlipChance = 0f;
    
    //Enemy attacking time
    public float chargeTime;
    float startChargeTime; //time it starts to run after specific time given in this var
    bool charging;
    Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		if(Time.time > nextFlipChance)
        {
            if(Random.Range(0f,10f) >= 1f)
                flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
	}
    void onTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player") //if tag is the Player
        {
            if(facingRight && collider.transform.position.x < transform.position.x)
            { //if player postion is behind enemy;; face the player
                flipFacing();
            } 
            else if(!facingRight && collider.transform.position.x > transform.position.x)
            { //if on otherside of enemy
                flipFacing();
            }
            canFlip = false; //once facing the right way ; don't flip
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }
    void onTriggerStay2D(Collider2D collider)
    {//if player is in the trigger range of enemy
        if(collider.tag == "Player")
        {
            if(startChargeTime < Time.time)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0)*enemySpeed);
                else enemyRB.AddForce(new Vector2(1, 0)*enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }
    void onTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f,0f);
            enemyAnimator.SetBool("isCharging", charging);
        }

    }

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
