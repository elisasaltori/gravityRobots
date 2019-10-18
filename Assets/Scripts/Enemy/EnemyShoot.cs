using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The player's gravity gun. Shoots "gravity fields" on input
 **/
public class EnemyShoot : MonoBehaviour
{

    [Header("Attributes")]
    public float speed = 10.0f; //shooting speed
    public float spawnDist = 0.05f;

    [System.Serializable]
    public struct Controls
    {
        public KeyCode shoot;
    }

    [Header("Controls")]
    public Controls controls;

    [Header("References")]
    public GameObject gravityFieldPrefab;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(controls.shoot))
        {
            Shoot();
            Debug.Log("Shoot");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(gravityFieldPrefab);
        bullet.transform.position = this.transform.position + transform.right * spawnDist;
        bullet.GetComponent<Rigidbody2D>().velocity = speed * transform.right;
    }
}