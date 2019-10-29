using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingMonsterController : MonoBehaviour
{
	public float speed = 3.0f;
    public int direction = -1;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        setFlipSpriteDirection();
        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vect.x, direction * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vect.x, direction * speed);
    }

    public int getDirection()
    {
    	return this.direction;
    }

    // Inverte no eixo-x o sprite
    void flipSprite()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void setFlipSpriteDirection() {
        if (transform.position.x > 0.56) {
            flipSprite();
        }
    }

    public void changeDirection()
    {
        if (transform.position.x > -0.83 && transform.position.x < 0.56) {
            flipSprite();
        }
        this.direction = this.direction * (-1);
        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vect.x, direction * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        changeDirection();
        
    }

    /*int OnTriggerEnter2D(Collider2D other)
    {
    	//Debug.Log("Object that entered the trigger : " + other);
    	//RubyController controller = other.GetComponent<RubyController>();

    	return (direction * (-1));
    }*/

    /*void OnCollisionEnter2D(Collision2D other)
	{
	    if(other.GetContacts() > 0){
	    	direction
	    }

	}*/

    /*int verifyWallHit(Vector2 position)
    {
    	if()

    	return new_direction
    }*/
}
