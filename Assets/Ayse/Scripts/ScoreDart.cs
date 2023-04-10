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
        float totalLastTime = PlayerPrefs.GetFloat("lastTime");

       
    }

       
    void Update()
    {

        //Debug.Log(scoreValue);
        //PlayerPrefs.SetFloat("lastTime", totalLastTime);
        //totalScore = scoreValue / totalLastTime;
        //
    }


    public Vector2 EndTheGame()
    {
        float totalLastTime = PlayerPrefs.GetFloat("lastTime");
        Debug.Log("Burasi" + totalLastTime);
        //Calculate score
        //Record score at SceneManager
        float calculatedScore = scoreValue / (100 - sld.lastTime) * 100;
        return new Vector2(calculatedScore, sld.lastTime);
    }


}

