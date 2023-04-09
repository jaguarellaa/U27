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

    public Slider work;
    public Slider school;
    public Slider wasteTime;

    public float gameTime;

    private bool stopTimer;

    void Start()
    {
        stopTimer = false;
        work.maxValue= gameTime;
        school.maxValue = gameTime;
        wasteTime.maxValue = gameTime;

        work.value = gameTime;
        school.value = gameTime;
        wasteTime.value = gameTime;






        SceneManagerScript[] objects = FindObjectsOfType<SceneManagerScript>();

        if (objects.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        float time = gameTime - Time.time;

        int minutes= Mathf.FloorToInt(time/60);
        int seconds=Mathf.FloorToInt(time - minutes* 60);

        if(time>=0)
        {
            stopTimer= true;
        }
        if(stopTimer==false)
        {
            work.value = time;
            school.value = time;
            wasteTime.value = time;
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

