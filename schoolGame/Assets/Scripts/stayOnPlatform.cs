using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOnPlatform : MonoBehaviour
{
    public GameObject platform;
    float movementSpeedX;
    float movementSpeedY;
    bool onPlatform;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(movementSpeedY);
        print(onPlatform);

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
    

    private void OnCollisionEnter2D(Collision2D coll)
    {
         platform = coll.gameObject;
        if (coll.gameObject.tag == "Platform")
        {
            movementSpeedX = platform.gameObject.GetComponent<platformScript>().movementSpeedX;
            movementSpeedY = platform.gameObject.GetComponent<platformScript>().movementSpeedY;
            
            transform.Translate(movementSpeedX / 10, movementSpeedY / 10, 0);
            onPlatform = true;
            print(onPlatform);
          
            print(movementSpeedY);

        }
        else
        {
            onPlatform = false;
          
        }
    }
    private void OnCollisionExit2D(Collision2D collis)
    {
        onPlatform = false;
        
    }
}