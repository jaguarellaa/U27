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

        float gameTime;
        bool keepCounting = true;

        private void Start()
        {
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
            keepCounting = false;
            //calculate academy points
            float totalPoints = (maxTime - gameTime) * pointMultipler;
            //activate end text
            endBox.SetActive(true);
        }
    }
}
