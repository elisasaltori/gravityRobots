using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCog : MonoBehaviour
{
    [Header("Attributes")]
    public float dropRate;
    public float cogZ = 2.1f;

    [Header("References")]
    public GameObject cog;

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }

    public void Cog(Transform transform)
    {
        //random chance to drop a cog
        if (Random.value < dropRate)
        {
           
            Vector3 pos = transform.position;
            pos = new Vector3(pos.x, pos.y-1f, cogZ);
            //drop cog
           
            GameObject newCog = Instantiate(cog, pos, transform.rotation);
            
        }
    }


}
