using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public float SocialTime = 100f;
    public float PuzzleTime = 100f;
    public float BowTime = 100f;
    public float AcademyScore = 0f;

    public GameObject playTwice;

    public bool[] sceneIDs = new bool[6];

    public float gameTime;

    private bool stopTimer;

    void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            sceneIDs[i] = false;
        }

        SceneManagerScript[] objects = FindObjectsOfType<SceneManagerScript>();

        if (objects.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        
    }

    public void ShowCantPlayTwice()
    {
        playTwice = GameObject.FindGameObjectWithTag("PlayTwice");
        playTwice.transform.localScale = new Vector3(1,1,1);
        StopCoroutine(disablePlayTwice());
        StartCoroutine(disablePlayTwice());
    }

    IEnumerator disablePlayTwice()
    {
        yield return new WaitForSeconds(3);
        playTwice.transform.localScale = new Vector3(0, 0, 0);
    }

    public void SetSceneIdTrue(int id)
    {
        if (id != 1)
        {
            sceneIDs[id] = true;
        }
        
    }

    public void LoadSceneByID(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetAcademyPoints(float score)
    {
        AcademyScore += score;
    }

    public void SetBowTime(float input)
    {
        BowTime -= input;
    }

    public void SetSocialTime(float input)
    {
        SocialTime -= input;
    }

    public void SetPuzzleTime(float input)
    {
        PuzzleTime -= input;
    }
}

