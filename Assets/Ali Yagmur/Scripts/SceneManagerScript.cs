using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    public float SocialTime = 100f;
    public float PuzzleTime = 100f;
    public float BowTime = 100f;
    public float AcademyScore = 0f;

    void Start()
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

    public void SetBowTime(float score)
    {
        BowTime -= score;
    }

    public void SetSocialTime(float score)
    {
        SocialTime -= score;
    }

    public void SetPuzzleTime(float score)
    {
        PuzzleTime -= score;
    }
}

