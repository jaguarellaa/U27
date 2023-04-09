﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bx;
    bool disableRotation;
    public float destroyTime = 10f;
    AudioSource arrowAudio;
    public int score=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        arrowAudio = GetComponent<AudioSource>();

        Destroy(this.gameObject, destroyTime);
    }
    void Update()
    {
        if(!disableRotation)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            arrowAudio.Play();
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;
        } 

        if(collision.gameObject.tag=="Score")
        {
            score += 1;
            Destroy(this.gameObject);
            Debug.Log(score);
        }
    }
}
