using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeDart: MonoBehaviour
   {
    public Image school;
  

    public float maxTime;
    
    float gameTimeDart;
    public float lastTime;


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
        PlayerPrefs.GetFloat("lastTimeDart");
        if (bow.bowSettings.arrowCount > 0)
        {

            gameTimeDart -= Time.deltaTime;
            school.fillAmount = gameTimeDart / maxTime;


        }

        else
      
        {
            
            lastTime = gameTimeDart;
            gameTimeDart = lastTime;
            PlayerPrefs.SetFloat("lastTimeDart", lastTime);
            Debug.Log(lastTime);


        }
    }






}

