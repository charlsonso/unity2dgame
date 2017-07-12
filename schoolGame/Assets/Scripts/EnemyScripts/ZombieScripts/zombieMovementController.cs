using System.Collections;
using UnityEngine;

public class zombieMovementController : MonoBehaviour {
    //ENEMY -ANIMATION- VARIABLES
    Animator enemyAnimator; //used to change animation between code eg. idle, walk, run
    public float enemySpeed;

    //ENEMY -TRANSFORMATION- VARIABLES
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false; //From png. the enemy starts off looking LEFT
    float flipTime = 5f; //Variable that keeps track of the possiblity that the enemy will be able to flip
    float nextFlipChance = 0f;

    //ENEMY CHARGE VARIABLES
    Rigidbody2D enemyRB;
    public float chargeTime;
    float startChargeTime; //time it starts to run after specific time given in this var
    bool charging;
    bool hitByPlayer;

    //VARIABLES TO KNOCKBACK PLAYER
    Rigidbody2D player; //obtain the rigidbody2D from 'mainCharacter'
    public float Xforce;

    void Start () {
        enemyAnimator = this.GetComponentInChildren<Animator>();
        enemyRB = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("mainCharacter").GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChance && gameObject != null && enemyAnimator != null && enemyRB != null)
        {
            if (Random.Range(0f, 10f) >= 1f)
                flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other) /*This function is used when the PLAYER -enters- trigger range of ENEMY*/
    {
        if (other.gameObject.tag == "Player" && gameObject != null && enemyAnimator != null && enemyRB != null)       //if tag is the Player
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            { //if player postion is behind enemy;; face the player
                flipFacing();
            } 
            else if(!facingRight && other.transform.position.x > transform.position.x)
            { //if on otherside of enemy
                flipFacing();
            }
            canFlip = false; //once facing the right way ; don't flip
            charging = true;
            startChargeTime = Time.time + chargeTime;

        } 
    }

    void OnTriggerStay2D(Collider2D other) /*This function is used when the PLAYER stays -within- the trigger range of ENEMY*/
    {
        if (other.gameObject.tag == "Player" && gameObject != null && enemyAnimator != null && enemyRB != null)
        {
            if (startChargeTime > Time.time)
            {
                if (!facingRight) enemyRB.velocity =(new Vector2(-1f, 0f) * enemySpeed); //AddForce increases speed over time!
                else enemyRB.velocity = (new Vector2(1f, 0f) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other) /*This function is used when the PLAYER -exits- the trigger range of ENEMY*/
    {
        StartCoroutine(wait(other,200)); //let enemy walk a bit after exiting trigger
        if (other.gameObject.tag == "Player" && gameObject != null && enemyAnimator != null && enemyRB != null)
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f) * enemySpeed;
            enemyAnimator.SetBool("isCharging", charging);
        }

    }

    void OnCollisionEnter2D(Collision2D coll) /*Push forward enemy to dmg player when collision detected*/
    {
        if (coll.gameObject.tag == "Player")
        {
            if (facingRight)
            {
                // Mathf.Pow(enemyRB.position.x - player.position.x, 2f) + Mathf.Pow(enemyRB.position.y - player.position.y, 2f);
                if (player.position.x <= 0f) player.AddForce(new Vector2(-player.position.x * Xforce, player.position.y));
                else player.AddForce(new Vector2(player.position.x * Xforce, player.position.y));
            }
            else if(!facingRight)
            { 
                if (player.position.x <= 0f) player.AddForce(new Vector2(player.position.x * Xforce, player.position.y));
                else player.AddForce(new Vector2(-player.position.x * Xforce, player.position.y));
            }

        }
    }

    void flipFacing() /*flipFacing() is used to change direction of enemy*/
    {
        if ( gameObject != null && enemyAnimator != null && enemyRB != null)
        {
            if (!canFlip) return;
            float facingX = enemyGraphic.transform.localScale.x;
            facingX *= -1f;
            enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
            facingRight = !facingRight;
        }
    }

    IEnumerator wait(Collider2D other, int seconds)
    {
        //have enemy walk around if Trigger is exited
        for (int i = 0; i < seconds; i++)
        {
            if (other != null && other.gameObject.tag == "Player" && gameObject != null && enemyAnimator != null && enemyRB != null)
            {
                if (!facingRight) enemyRB.velocity = (new Vector2(-.5f, 0f) * enemySpeed); //AddForce increases speed over time!
                else enemyRB.velocity = (new Vector2(.5f, 0f) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);
            }
            yield return (0);
        }
    }
}