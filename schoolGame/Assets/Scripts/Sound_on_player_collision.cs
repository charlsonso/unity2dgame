using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_on_player_collision : MonoBehaviour {
    public AudioClip collisionsound;
    public float volume;
    private AudioSource source;
  

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            source.PlayOneShot(collisionsound, volume);
            print("hit");
        }
      }
}
