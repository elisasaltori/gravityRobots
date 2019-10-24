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


    public float[] chances = new float[] { 0.4f, 0.4f, 0.2f}; //random chance for each 
    public int[] waveTime = new int[] {160, 140, 80, 10};
    public int speedUpPoints = 50; 

    public float spawnTime = 3f; //time between monsters (in seconds)

    private Countdown timer;

    void Start()
    {
        timer = GameObject.Find("Countdown").GetComponent<Countdown>();

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    int GetEnemyType()
    {
        float time = timer.GetTime();
        
        if(time > waveTime[0])
        {
            //Debug.Log("wave 0");
            return 0;
        }
        
        if(time > waveTime[1])
        {
            Debug.Log("wave 1");
            return (int)Random.Range(0, 2);
        }

        Debug.Log("wave 2");
        return (int)Random.Range(0, enemyPrefabs.Length);
    }

    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //get enemy type
        int enemyType = GetEnemyType();


        //get enemy z spawn position
        float spawnZ = Random.Range(zMinSpawn, zMaxSpawn);

        Vector3 pos = spawnPoints[spawnPointIndex].position;
        pos.z = spawnZ;

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyPrefabs[enemyType], pos, spawnPoints[spawnPointIndex].rotation);
    }


}
