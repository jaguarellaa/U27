using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PK.GameJam
{
    public class LevelComplete : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PlayerTag))
            {
                GameStartSignal.Trigger(false);
                SceneManager.LoadScene("ANA HOL");
            }
        }
    }
}
