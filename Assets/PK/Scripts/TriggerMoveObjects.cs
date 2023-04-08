using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK.GameJam
{
    public class TriggerMoveObjects : MonoBehaviour
    {
        [SerializeField] private int obstackleIndex;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag))
                MoveObstackleOpenSignal.Trigger(obstackleIndex);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag))
                MoveObstackleCloseSignal.Trigger(obstackleIndex);
        }
    }
}
