using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10.0f; //shooting speed
    public float spawnDist = 0.05f;
    public float dir = 1;
    public float shootingRate = 0.75f; // frenquencia de disparo (quanto maior a frequencia, menos disparos por segundo)
    public float monsterType = 1; // define se o tiro foi disparado pelo monstro roxo ou verde

    private float shootCooldown; // controla a frequencia de disparos do mosntro
    private Animator animator;


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
        shootCooldown = 0;	
    }

    // Update is called once per frame
    void Update()
    {
    	if (shootCooldown > 0) 
		{
			shootCooldown -= Time.deltaTime;
		}
        
        Shoots();
    }

    private void Shoots()
    {
    	if (shootCooldown <= 0)
		{
            animator.SetTrigger("shooting");
            shootCooldown = shootingRate;
            // direcionamento do tiro para sempre sair pela frente do monstro (verificando o sentido do mosntro)
			if (monsterType == 1)
		    {
	        	facing = gameObject.GetComponent<MonstroSimplesController>().facingRight;
		    }
		    else if (monsterType == 2)
		    {
	        	facing = gameObject.GetComponent<flyingMonsterController>().facingRight;
		    }
	        if (facing)
	        {
	            dir = 1;
	        } else
	        {
	            dir = -1;
	        }

            FindObjectOfType<AudioManager>().Play("MonsterShoot");

            // instanciamento do tiro na tela após o disparo do monstro
            GameObject bullet = Instantiate(bomb);
	        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
	        bullet.transform.position = (this.transform.position + transform.right * (dir *spawnDist));
	        bullet.GetComponent<Rigidbody2D>().velocity = dir * (speed * transform.right);
		}
    }
}
