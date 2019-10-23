using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement
public class PlayerMovement : MonoBehaviour
{
    // Atributos
    [Header("Attributes")]
    public float speed = 20;
    public float jumpForce = 500;
    public bool facingRight = true;

    [System.Serializable]
    public struct Controls
    {
        public KeyCode up;
        public KeyCode down;
        public KeyCode right;
        public KeyCode left;
    }

    [Header("Controls")]
    public Controls controls;

    public LayerMask isGround;
    private int layerMask = ~(1 << 8); //all layers but layer 8 (Player)


    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    
    private float horizontalMove;
    private float verticalMove;
    public bool stunned = false;

    // Called before start
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        if (!facingRight)
        {
            flipSprite();
            facingRight = !facingRight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            
            if (Input.GetKey(controls.right))
            {
                horizontalMove = 1;
            } else if (Input.GetKey(controls.left))
            {
                horizontalMove = -1;
            } else
            {
                horizontalMove = 0;
            }

            
            if (Input.GetKey(controls.up))
            {
                verticalMove = 1;
            } else
            {
                verticalMove = 0;
            }
        }
    }

    // Used for physics, fixed intervals
    private void FixedUpdate()
    {

        rb.AddForce(Vector2.right * horizontalMove * speed);
       
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        //flips sprite to match movement
        if (horizontalMove > 0 && !facingRight)
        {
            flipSprite();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flipSprite();
        }

        // if the player is not in the air and there is vertical movement, player jumps
        if (verticalMove > 0 && isOnGround())
        {
            animator.SetTrigger("jumping");
            rb.AddForce(Vector2.up * verticalMove * jumpForce);
        }
    }

    // Flips sprite horizontally
    void flipSprite()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //Checks if the sprite is in contact with the floor
    public bool isOnGround()
    {
 
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.15f;

        //raycast ignores player layer due to layerMask
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, layerMask);
        if (hit.collider != null && rb.velocity.y == 0)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "monstro_simples(Clone)")
        {
            //on collision with a monster, stun player
            Stun();
        }
    }

    private void Stun()
    {
        // rb.velocity = Vector2.zero;
        //rb.sleepMode
        stunned = true;
        animator.SetBool("stunned", true);
        horizontalMove = 0;
        verticalMove = 0;
        StartCoroutine(wait(2));
        //stunned = false;
    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
        animator.SetBool("stunned", false);
        stunned = false;
    }
}