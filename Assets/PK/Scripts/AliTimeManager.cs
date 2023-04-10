using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK
{
    public class AliTimeManager : MonoBehaviour
    {
        [SerializeField] float maxTime;
        [SerializeField] float pointMultipler;
        [SerializeField] GameObject endText;
        [SerializeField] GameObject endBox;

        [SerializeField] GameObject sceneManager;

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
