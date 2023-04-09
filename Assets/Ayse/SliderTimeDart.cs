using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeDart: MonoBehaviour
   {
    public Image school;
  

    public float maxTime;

    float gameTimeDart;
  


    public Bow bow;


    void Start()
    {

        gameTimeDart = maxTime;
       
    }


    void Update()
    {

        GameSliderDart();

    }

    public void GameSliderDart()
    {
        PlayerPrefs.GetFloat("lastTimeDart", gameTimeDart);
        if (bow.bowSettings.arrowCount > 0)
        {

            gameTimeDart -= Time.deltaTime;
            school.fillAmount = gameTimeDart / maxTime;


        }

        else
      
        {
            
            float lastTime = gameTimeDart;
            gameTimeDart = lastTime;
            PlayerPrefs.SetFloat("lastTime", lastTime);
            Debug.Log(lastTime);

        }
    }






}

