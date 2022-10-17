using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour
{
    public AudioSource SmallObject;
    public AudioSource MediumObject;
    public AudioSource BigObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SmallObstacles")
        {
            SmallObject.Play();
        }

        if(collision.tag == "MediumObstacles")
        {
            MediumObject.Play();
        }

        if(collision.tag == "BigObstacles")
        {
            BigObject.Play();
        }
    }
}
