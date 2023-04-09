using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PressE : MonoBehaviour
{
    [SerializeField] GameObject textPressE;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        textPressE.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        textPressE.SetActive(true);
    }

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            //make the action
        }
    }
}

