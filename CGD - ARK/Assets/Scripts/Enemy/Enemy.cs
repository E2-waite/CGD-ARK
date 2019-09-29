﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool chaseActive;
    [SerializeField] private GameObject player;
    [SerializeField] private float patrolDelay;

    public float speed;
    public bool chasing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chasing)
        {
            Chase();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            //testing, please change sound
            AudioManager.instance.Play("Sisters");
            chasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            //testing, please change sound
            AudioManager.instance.Stop("Sisters");
            chasing = false;
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    }

    void Patrol()
    {

    }
}