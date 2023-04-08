using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialEnemySpawner : MonoBehaviour
{
    [SerializeField] Transform playerLocation;

    [SerializeField] float minSpawnX;
    [SerializeField] float maxSpawnX;

    [SerializeField] float minSpawnZ;
    [SerializeField] float maxSpawnZ;

    [SerializeField] float minSpawnDistance;

    [SerializeField]
    [Range(1, 3)]
    [Tooltip("Hardness level between 1 and 3.")]
    private int HardnessLevel = 1;

    //75 20 5
    //50 40 10
    //30 40 30

    private float spawnTimer;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    public bool GameIsOn = false;

    [SerializeField] GameObject SocialEnemyV1Prefab;
    [SerializeField] GameObject SocialEnemyV2Prefab;
    [SerializeField] GameObject SocialEnemyV3Prefab;

    void Start()
    {
        spawnTimer = 3f;
        StartSpawningEnemies();
    }

    public void StopSpawningEnemies()
    {
        GameIsOn = false;
    }

    public void StartSpawningEnemies()
    {
        GameIsOn = true;
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        while(GameIsOn)
        {
            bool LocationIsNotFoundYet = true;
            //Spawn in a random place and make the next spawn timer also random.
            Vector3 spawnLocation = Vector3.zero;
            while (LocationIsNotFoundYet)
            {
                spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), 0, Random.Range(minSpawnZ, maxSpawnZ));
                if ((playerLocation.position - spawnLocation).magnitude > minSpawnDistance)
                {
                    LocationIsNotFoundYet = false;
                }
            }
            

            int randomInt = Random.Range(1, 101);

            GameObject EnemyToBeSpawned;

            if (HardnessLevel == 1)
            {
                if (randomInt <=75)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 95)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
            }
            else if (HardnessLevel == 2)
            {
                if (randomInt <= 50)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 90)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
            }
            else
            {
                if (randomInt <= 30)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 70)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
            }
            GameObject newEnemy = Instantiate(EnemyToBeSpawned, spawnLocation, Quaternion.identity);

            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTimer);
        }        
    }
}
