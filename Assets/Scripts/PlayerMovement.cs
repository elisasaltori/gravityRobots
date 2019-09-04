using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este codigo controla o movimento do jogador
public class PlayerMovement : MonoBehaviour
{
    // Atributos
    [Header("Attributes")]
    public float speed = 20;
    public float jumpForce = 500;
    public bool facingRight = true;
    public LayerMask isGround;


    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private float horizontalMove;
    private float verticalMove;

    // Chamado antes de start
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
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    // Used for physics, fixed intervals
    private void FixedUpdate()
    {

        rb.AddForce(Vector2.right * horizontalMove * speed);
        //Vector2 vect = rb.velocity;
        //rb.velocity = new Vector2(horizontalMove * speed, vect.y);
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (horizontalMove > 0 && !facingRight)
        {
            flipSprite();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flipSprite();
        }

        // Se nao estiver no ar e existir movimento vertical, pula
        if (verticalMove > 0 && isOnGround())
        {
            animator.SetTrigger("jumping");
            rb.AddForce(Vector2.up * verticalMove * jumpForce);
        }
    }

    // Inverte no eixo-x o sprite
    void flipSprite()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //Checa se esta "pisando"
    public bool isOnGround()
    {
        //bool groundCheck = Physics2D.Raycast(new Vector2(transform.position.x,
        // transform.position.y - height),
        // -Vector2.up, rayCastLength);
        //if (groundCheck) return true;
        //if (rb.velocity.y == 0) return true;
        //return false;

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.25f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, isGround);
        if (hit.collider != null && rb.velocity.y == 0)
        {
            return true;
        }

        return false;
    }
}