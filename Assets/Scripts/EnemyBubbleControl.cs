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
        field.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
