using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Attributes")]
    public float speed = 10.0f; //shooting speed
    public float spawnDist = 0.05f;
    public float dir = 1;

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
        if (Input.GetKeyDown(controls.shoot))
        {
            animator.SetTrigger("shooting");
            Shoots();
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
        bullet.transform.position = (this.transform.position + transform.right * (dir *spawnDist));
        bullet.GetComponent<Rigidbody2D>().velocity = dir * (speed * transform.right);
    }
}
