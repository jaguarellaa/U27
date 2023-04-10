using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace PK
{
    public class DisableWithTime : MonoBehaviour
    {
        GameObject sceneManager;

        [SerializeField] GameObject creditText;

        [SerializeField] GameObject panel;

        [SerializeField] TextMeshProUGUI social;
        [SerializeField] TextMeshProUGUI practical;
        [SerializeField] TextMeshProUGUI work;

        [SerializeField] TextMeshProUGUI totalScore;

        int tutorialCounter = 0;

        IEnumerator pressEforCredits()
        {
            while(true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(2);
                }
                yield return new WaitForEndOfFrame();
                
            }
        }

        private void Start()
        {
            sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
            if (sceneManager.GetComponent<SceneManagerScript>().sceneIDs[3] == true)
            {
                practical.text = "Practical Training: Completed";
                tutorialCounter++;
            }
            else
            {
                practical.text = "Practical Training: Incomplete";
            }
            if (sceneManager.GetComponent<SceneManagerScript>().sceneIDs[4] == true)
            {
                work.text = "Technical Training: Completed";
                tutorialCounter++;
            }
            else
            {
                work.text = "Technical Training: Incomplete";
            }
            if (sceneManager.GetComponent<SceneManagerScript>().sceneIDs[5] == true)
            {
                social.text = "Social Training: Completed";
                tutorialCounter++;
            }
            else
            {
                social.text = "Social Training: Incomplete";
            }
            if (tutorialCounter == 0)
            {
                totalScore.text = "0";
            }
            else
            {
                totalScore.text = (sceneManager.GetComponent<SceneManagerScript>().AcademyScore / tutorialCounter).ToString();
            }
            if (tutorialCounter == 3)
            {
                creditText.SetActive(true);

            }
            StartCoroutine(DisableIn());
        }

        

        IEnumerator DisableIn()
        {
            yield return new WaitForSeconds(5);
            panel.SetActive(false);
        }
    }
}
