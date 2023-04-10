using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PK
{
    public class AliTimeManager : MonoBehaviour
    {
        [SerializeField] float maxTime;
        [SerializeField] float pointMultipler;
        [SerializeField] GameObject endText;
        [SerializeField] GameObject endBox;

        GameObject sceneManager;

        public Slider workSlider;

        bool gameIsOver = false;


        float gameTime;
        bool keepCounting = true;

        private void Start()
        {
            workSlider.maxValue= maxTime;
            sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
            gameTime = 0;
        }

        private void Update()
        {
            if (keepCounting == true)
            {
                gameTime += Time.deltaTime;
                workSlider.value = maxTime-gameTime;
            }
        }

        public void GameCopleted()
        {
            if (gameIsOver == false)
            {
                keepCounting = false;
                //calculate academy points
                float totalPoints = (maxTime - gameTime)/200 ;
                totalPoints *= 100;
                Debug.Log(totalPoints);
                sceneManager.GetComponent<SceneManagerScript>().SetAcademyPoints(totalPoints);
                sceneManager.GetComponent<SceneManagerScript>().PuzzleTime = gameTime;
                //activate end text
                endBox.SetActive(true);
                gameIsOver = true;
            }
            
        }
    }
}
