using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PressE : MonoBehaviour
{
    [SerializeField] GameObject textPressE;
    private bool isTriggered = false;
    [SerializeField] int loadSceneID;

    GameObject sceneManager;


    private void Start()
    {
        sceneManager = GameObject.FindWithTag("SceneManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            textPressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            textPressE.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && sceneManager.GetComponent<SceneManagerScript>().sceneIDs[loadSceneID] == false)
        {
            if (loadSceneID != 1)
            {
                sceneManager.GetComponent<SceneManagerScript>().sceneIDs[loadSceneID] = true;
            }
            
                sceneManager.GetComponent<SceneManagerScript>().LoadSceneByID(loadSceneID);
            
            
            //make the action
        }
        else if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (loadSceneID != 1)
            {
                sceneManager.GetComponent<SceneManagerScript>().ShowCantPlayTwice();
            }
        }
    }
}

