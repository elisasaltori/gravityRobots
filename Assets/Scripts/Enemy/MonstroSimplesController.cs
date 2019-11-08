using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroSimplesController : MonoBehaviour
{
	public float speed = 3.0f;
    public int direction = -1;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
 
        flipSprite();
        SetRandomDirection();
        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, vect.y);
    }

    //called when monster starts so it's facing a random direction (right or left)
    void SetRandomDirection()
    {
        int rand = Random.Range(0, 2);
       
        if (rand == 1)
            changeDirection();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, vect.y);

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

    public void changeDirection()
    {
        flipSprite();
        this.direction = this.direction * (-1);
        Vector2 vect = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, vect.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        changeDirection();
        
    }
}
