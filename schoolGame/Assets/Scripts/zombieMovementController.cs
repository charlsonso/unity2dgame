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

    void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChance && !gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null))
        {
            if (Random.Range(0f, 10f) >= 1f)
                flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other) /*This function is used when the PLAYER -enters- trigger range of ENEMY*/
    {
        Debug.Log("enter");

        if (other.gameObject.tag == "Player" && !gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null))        //if tag is the Player
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
        if (other.gameObject.tag == "Player" && !gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null))
        {
            if (startChargeTime > Time.time)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1f, 0f) * enemySpeed); //AddForce increases speed over time!
                else enemyRB.AddForce(new Vector2(1f, 0f) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other) /*This function is used when the PLAYER -exits- the trigger range of ENEMY*/
    {
        Debug.Log("exit");

        StartCoroutine(wait(other,200)); //let enemy walk a bit after exiting trigger
        if (other.gameObject.tag == "Player" && !gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null))
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f) * enemySpeed;
            enemyAnimator.SetBool("isCharging", charging);
        }

    }

    void OnCollisionEnter2D(Collision2D coll) /*Push forward enemy to dmg player when collision detected*/
    {
        Debug.Log("Collided");
        if (coll.gameObject.tag == "Player")
        {
            if (facingRight == true)
            {
                 enemyRB.AddForce(new Vector2(10, enemyRB.position.y) * enemySpeed, ForceMode2D.Impulse);
            }
            else if(facingRight == false)
            {
                enemyRB.AddForce(new Vector2(-10, enemyRB.position.y) *enemySpeed, ForceMode2D.Impulse);

            }

        }
    }

    void flipFacing() /*flipFacing() is used to change direction of enemy*/
    {
        if (!gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null)) {
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
            if (other.gameObject.tag == "Player" && !gameObject.Equals(null) && !enemyAnimator.Equals(null) && !enemyRB.Equals(null))
            {
                if (!facingRight) enemyRB.velocity = (new Vector2(-.5f, 0f) * .5f* enemySpeed); //AddForce increases speed over time!
                else enemyRB.velocity = (new Vector2(.5f, 0f) * enemySpeed);
                enemyAnimator.SetBool("isCharging", charging);

            }
            yield return (0);
        }

        //do stuff after the 2 seconds
    }
}