using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class ScoreDart : MonoBehaviour
{
    public static float scoreValue;
    public SliderTimeDart sld;
    public float totalScore;
    public float totalLastTime;

    void Start()
    {
        float totalLastTime= PlayerPrefs.GetFloat("lastTime");

       
    }

       
    void Update()
    {

        Debug.Log(scoreValue);
        //PlayerPrefs.SetFloat("lastTime", totalLastTime);
        //totalScore = scoreValue / totalLastTime;
        Debug.Log(totalScore);
    }
 }

