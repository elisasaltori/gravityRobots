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


    public float[] chances = new float[] { 0.4f, 0.4f, 0.2f}; //random chance for each monster
    public int[] waveTime = new int[] {160, 140, 80}; //match times at which new monsters start spawning

    public float spawnTime = 3f; //time between monsters (in seconds)
    public float secondSpawnTime = 50.5f; //time to add a second spawner
    public float thirdSpawnTime = 10f; //time to add a third spawner

    public int monsterLimit = 20; //max number of monsters on screen at one time
    private int monsterCount;

    private bool secondSpawnerUp;
    private bool thirdSpawnerUp;
    private Countdown timer;

    void Start()
    {
        timer = GameObject.Find("Countdown").GetComponent<Countdown>();
        monsterCount = 0;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        secondSpawnerUp = false;

    }

    private void Update()
    {
        //get second spawner up
       if(timer.GetTime()< secondSpawnTime && !secondSpawnerUp)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            secondSpawnerUp = true;

        }

        //get third spawner up
        if (timer.GetTime() < thirdSpawnTime && !thirdSpawnerUp)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            thirdSpawnerUp = true;

        }
    }

    //returns index for enemy type
    int GetEnemyType()
    {
        float time = timer.GetTime();
        
        //First wave: only simple monsters
        if(time > waveTime[0])
        {
            return 0;
        }

        float num;
        
        //Second wave: add shooting monsters
        if(time > waveTime[1])
        {
            num = Random.Range(0, chances[0] + chances[1]);

            if (num > chances[0])
                return 1;

            return 0;

        }

        //third wave: add flying monster
        num = Random.Range(0f, 1f);

        if (num > chances[0] + chances[1])
            return 2;
        if (num > chances[0])
            return 1;
        return 0;
    }

    void Spawn()
    {
        //dont spawn if at monster limit!
        if (monsterCount >= monsterLimit)
            return;

        monsterCount++;

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //get enemy type
        int enemyType = GetEnemyType();
        Debug.Log("enemy "+enemyType);

        //get enemy z spawn position
        float spawnZ = Random.Range(zMinSpawn, zMaxSpawn);

        Vector3 pos = spawnPoints[spawnPointIndex].position;
        pos.z = spawnZ;

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyPrefabs[enemyType], pos, spawnPoints[spawnPointIndex].rotation);
    }

    public void DecreaseMonsterCount()
    {
        monsterCount--;
    }


}
