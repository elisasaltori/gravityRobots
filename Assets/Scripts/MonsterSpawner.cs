using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("References")]
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    [Header("Attributes")]
    //monsters are spawned in a z interval so that they don't occupy the same space
    //if that happens, the images glitch
    public float zMinSpawn = 1.0f;
    public float zMaxSpawn = 1.8f;
    

    public float spawnTime = 3f;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //get enemy type
        int enemyType = (int) Random.Range(0, enemyPrefabs.Length);

        //get enemy z spawn position
        float spawnZ = Random.Range(zMinSpawn, zMaxSpawn);

        Vector3 pos = spawnPoints[spawnPointIndex].position;
        pos.z = spawnZ;

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyPrefabs[enemyType], pos, spawnPoints[spawnPointIndex].rotation);
    }


}
