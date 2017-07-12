using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOnPlatform : MonoBehaviour
{
    public GameObject platform;
    float movementSpeedX = 1;
    float movementSpeedY = 0;
    bool onPlatform;
    Transform transplat;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        if (onPlatform == true)
        {
            if (GetComponent<playerController>().grounded == true)
            {

                if (platform.gameObject.GetComponent<platformScript>().reversed == false)
                {
                    transform.Translate(movementSpeedX / 10, movementSpeedY / 10, 0);
                }
                else
                {
                    transform.Translate(-1 * (movementSpeedX / 10), -1 * (movementSpeedY / 10), 0);
                }

            }

        }
    }

    //makes a character stay on a moving platform by granting that character the same transform
    private void OnCollisionEnter2D(Collision2D coll)
    {
       
        if (coll.gameObject.tag == "Platform")
        {
            platform = coll.gameObject;
            transplat = platform.transform;
            onplatform(transplat);
         
        }
        else
        {
            offplatform(transplat);
            onPlatform = false;

        }
    }

    //on leaving the platform removes that transform
    private void OnCollisionExit2D(Collision2D collis)
    {
        onPlatform = false;
        offplatform(transplat);
    }

    public void onplatform(Transform platform)
    {
        this.transform.SetParent(platform, true);
    }
    public void offplatform(Transform platform)
    {
        this.transform.parent = null;
    }
}