using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PK
{
    public class Anamenü : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void CreditsScene()
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
