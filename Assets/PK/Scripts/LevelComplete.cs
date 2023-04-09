using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PK.GameJam
{
    public class LevelComplete : MonoBehaviour
    {
        GameObject timeManager;

        private void Start()
        {
            timeManager = GameObject.FindWithTag("TimeManager");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PlayerTag))
            {
                GameStartSignal.Trigger(false);
                timeManager.GetComponent<AliTimeManager>().GameCopleted();
            }
        }
    }
}
