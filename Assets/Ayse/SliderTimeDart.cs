using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeDart: MonoBehaviour
   {
    public Image school;

    private SceneManagerScript manager;
    private ScoreDart dart;
    public float maxTime;
    
    public float gameTimeDart;
    public float lastTime;


    public Bow bow;

    private void Awake()
    {
        dart = GameObject.FindAnyObjectByType<ScoreDart>();
    }
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
            
            //lastTime = gameTimeDart;
            //gameTimeDart = lastTime;
            PlayerPrefs.SetFloat("lastTimeDart", gameTimeDart);
            Debug.Log(gameTimeDart);
            dart.totalLastTime = gameTimeDart;
        }
    }






}

