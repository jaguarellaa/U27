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

        public Image workSlider;

        bool gameIsOver = false;


        float gameTime;
        bool keepCounting = true;

        private void Start()
        {
            sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
            gameTime = maxTime;
        }

        private void Update()
        {
            if (keepCounting == true)
            {
                gameTime -= Time.deltaTime;
                workSlider.fillAmount = gameTime / maxTime;
            }
        }

        public void GameCopleted()
        {
            if (gameIsOver == false)
            {
                keepCounting = false;
                //calculate academy points
                float totalPoints = (maxTime - gameTime) * pointMultipler;
                if (totalPoints > 100)
                {
                    totalPoints = 100;
                }
                sceneManager.GetComponent<SceneManagerScript>().SetAcademyPoints(totalPoints);
                sceneManager.GetComponent<SceneManagerScript>().PuzzleTime = gameTime;
                //activate end text
                endBox.SetActive(true);
                gameIsOver = true;
            }
            
        }
    }
}
