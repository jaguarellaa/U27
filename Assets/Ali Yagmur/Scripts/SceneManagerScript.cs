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



    public float gameTime;

    private bool stopTimer;

    void Awake()
    {


        SceneManagerScript[] objects = FindObjectsOfType<SceneManagerScript>();

        if (objects.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
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

