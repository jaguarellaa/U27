using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK.GameJam
{
    public class LevelComplete : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PlayerTag))
            {
                Debug.Log("LevelCompleted");
            }
        }
    }
}
