using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderSetScript : MonoBehaviour
{
    GameObject sceneManager;
    [SerializeField] Slider work;
    [SerializeField] Slider school;

    [SerializeField] Slider socialSlider;


    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");

        socialSlider.value = sceneManager.GetComponent<SceneManagerScript>().SocialTime / 100;
        work.value = sceneManager.GetComponent<SceneManagerScript>().PuzzleTime / 100;
        school.value = sceneManager.GetComponent<SceneManagerScript>().BowTime / 100;
    }


}

