﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Attributes")]
    public float speed = 10.0f; //speed of projectile
    public float spawnDist = 0.05f; // Distance of player
    public float dir = 1; //direction

    private Animator animator;

    [System.Serializable]
    public struct Controls
    {
        public KeyCode shoot;

    }

    [Header("Controls")]
    public Controls controls;

    [Header("References")]
    public GameObject bomb;

    private bool facing;
    private bool stunned;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stunned = gameObject.GetComponent<PlayerMovement>().stunned;
        if (!stunned)
        {
            if (Input.GetKeyDown(controls.shoot) &&
                GameObject.FindGameObjectsWithTag((bomb.name)).Length <= 2)
            {
                
                animator.SetTrigger("shooting");
                Shoots();
            }
        }
    }

    private void Shoots()
    {
        FindObjectOfType<AudioManager>().Play("GravityGunShoot");

        facing = gameObject.GetComponent<PlayerMovement>().facingRight;
        if (facing)
        {
            dir = 1;
        } else
        {
            dir = -1;
        }
        
        GameObject bullet = Instantiate(bomb);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        bullet.transform.position = (this.transform.position + transform.right * (dir *spawnDist));
        bullet.GetComponent<Rigidbody2D>().velocity = dir * (speed * transform.right);
    }
}
