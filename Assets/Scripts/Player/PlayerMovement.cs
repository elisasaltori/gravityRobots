using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player movement
public class PlayerMovement : MonoBehaviour
{
    // Atributos
    [Header("Attributes")]
    public float speed = 20;
    public float maxVelocity = 5;
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
    private Renderer objRender;

    
    private float horizontalMove;
    private float verticalMove;
    public bool stunned = false;
    public bool gracePeriod = false;
    private float alpha = 0.5f;
    private int counter = 0;

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
        // Enter if player is not stunned
        if (!stunned)
        {
            // Blinking player in grace period
            if (gracePeriod)
            {
                objRender = GetComponent<Renderer>();
                objRender.material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
                if (counter > 10)
                {
                    if (alpha != 1.0f)
                    {
                        alpha = 1.0f;
                    } else
                    {
                        alpha = 0.5f;
                    }
                    counter = 0;
                }
                counter++;
            }
            
            // Player goes right or left
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

            // Player jumps
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

        //caps player horizontal speed
        if (rb.velocity.x > maxVelocity)
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
       
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        // Flips sprite to match movement
        if (horizontalMove > 0 && !facingRight)
        {
            flipSprite();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flipSprite();
        }

        // If the player is not in the air and there is vertical movement, player jumps
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

        // Raycast ignores player layer due to layerMask
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, layerMask);
        if (hit.collider != null && rb.velocity.y == 0)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with a monster, stun player
        if (collision.gameObject.tag == "Enemy")
        {
            Stun();
        }
    }

    // Used to stop player movement and shooting for some time after being hit
    public void Stun()
    {
      //;; ; Time.timeScale = 0;
        // If is in grace period, player is not stunned again
        if(gracePeriod == true)
        {
            return;
        }

        stunned = true;
        animator.SetBool("stunned", true);
        horizontalMove = 0;
        verticalMove = 0;
        StartCoroutine(wait(2));

        FindObjectOfType<AudioManager>().Play("RobotStunned");
    }

    // Wait stunned
    IEnumerator wait(int sec)
    {
        gracePeriod = true;
        yield return new WaitForSeconds(sec);
        animator.SetBool("stunned", false);
        stunned = false;
        StartCoroutine(waitGP(2));

    }

    // Wait grace period
    IEnumerator waitGP(int sec)
    {
        //objRender = GetComponent<Renderer>();
        //objRender.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        yield return new WaitForSeconds(sec);
        objRender.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        gracePeriod = false;
        Debug.Log("GRACE PERIOD");
    }
}