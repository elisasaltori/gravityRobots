using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBubbleControl : MonoBehaviour
{

    [Header("References")]
    public GameObject fieldWithMonster;

    public void EnemyHit()
    {
        GameObject field = Instantiate(fieldWithMonster);
        //spawns filled field a little above monster so it doesnt get stuck to a platform
        field.transform.position = this.transform.position + new Vector3(0f, 0.1f, 0f); 
        Destroy(gameObject);
    }
}
