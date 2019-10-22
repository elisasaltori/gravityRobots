using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTime : MonoBehaviour
{

	private EnemyWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<EnemyWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null) {
        	weapon.Attack();
        }
    }
}
