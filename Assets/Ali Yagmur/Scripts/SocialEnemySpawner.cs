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

    // 40 20 10 - 30
    // 40 25 15 - 20
    // 25 35 20 - 20

    private float spawnTimer;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    public bool GameIsOn = false;

    [SerializeField] GameObject SocialEnemyV1Prefab;
    [SerializeField] GameObject SocialEnemyV2Prefab;
    [SerializeField] GameObject SocialEnemyV3Prefab;
    [SerializeField] GameObject StudyPrefab;

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
                if (randomInt <=40)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 60)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else if (randomInt <= 70)
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
                else
                {
                    EnemyToBeSpawned = StudyPrefab;
                }
            }
            else if (HardnessLevel == 2)
            {
                if (randomInt <= 40)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 65)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else if (randomInt <= 80)
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
                else
                {
                    EnemyToBeSpawned = StudyPrefab;
                }
            }
            else
            {
                if (randomInt <= 30)
                {
                    EnemyToBeSpawned = SocialEnemyV1Prefab;
                }
                else if (randomInt <= 50)
                {
                    EnemyToBeSpawned = SocialEnemyV2Prefab;
                }
                else if (randomInt <= 70)
                {
                    EnemyToBeSpawned = SocialEnemyV3Prefab;
                }
                else
                {
                    EnemyToBeSpawned = StudyPrefab;
                }
            }
            GameObject newEnemy = Instantiate(EnemyToBeSpawned, spawnLocation, Quaternion.identity);

            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTimer);
        }        
    }
}
