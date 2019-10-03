using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBubbleControl : MonoBehaviour
{

    [Header("References")]
    public GameObject fieldWithMonsteRed;
    public GameObject fieldWithMonsterYellow;

    public void EnemyHit(bool isPlayerOne)
    {
        GameObject field;

        //uses appropriate bubble color
        if (isPlayerOne)
            field = Instantiate(fieldWithMonsterYellow);
        else
            field = Instantiate(fieldWithMonsteRed);

        //spawns filled field a little above monster so it doesnt get stuck to a platform
        field.transform.position = this.transform.position + new Vector3(0f, 0.1f, 0f); 
        Destroy(gameObject);
    }
}
