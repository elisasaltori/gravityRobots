using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Attributes")]
    public float speed = 10.0f; //speed of projectile
    public float spawnDist = 0.05f; // Distance of player
    public float dir = 1; //direction
    //public float fireRate = 0.1f; //shooting cooldown

    private Animator animator;

    [System.Serializable]
    public struct Controls
    {
        public KeyCode shoot;

        public KeyCode shootJoystick;
    }

    [Header("Controls")]
    public Controls controls;

    [Header("References")]
    public GameObject bomb;

    private bool facing;
    private bool stunned;
    //private float nextFire = 0.01f;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        //dir = gameObject.GetComponent<PlayerMovement>().facingRight;
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
            //if (Input.GetKeyDown(controls.shoot) && Time.time > nextFire)
            if ((Input.GetKeyDown(controls.shoot) || Input.GetKeyDown(controls.shootJoystick))
                && GameObject.Find((bomb.name) + "(Clone)") == null)
            {
                //nextFire = Time.time + fireRate;
                //Debug.Log(Time.time);
                animator.SetTrigger("shooting");
                Shoots();
            }
        }
    }

    private void Shoots()
    {
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
