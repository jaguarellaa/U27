using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public Bow bow;
    [SerializeField] private GameObject[] targets;
    [SerializeField] float timeIntervalForTargets;

    private int lastTargetID = 0;

    bool GameIsOn = false;
    private bool repetitionChecker = true;


  

    private void Start()
    {
        startGame();
    }

    public void startGame()
    {
        GameIsOn = true;
        StartCoroutine(SpawnTargets());
    }

    public void arrowHitReset()
    {
        StopCoroutine(SpawnTargets());
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (GameIsOn)
        {
            int randomInt = 1;
            while (repetitionChecker)
            {
                randomInt = Random.Range(0, 8);
                if (lastTargetID != randomInt)
                {
                    repetitionChecker = false;
                }
            }
            repetitionChecker = true;

            targets[randomInt].SetActive(true);

            yield return new WaitForSeconds(timeIntervalForTargets);

            targets[randomInt].SetActive(false);
        }
    }

  




}