using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK.GameJam
{
    public class TriggerMoveObjects : MonoBehaviour
    {
        [SerializeField] private int obstackleIndex;
        private Renderer _renderer;
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag))
            {
                _renderer.material.color = Color.green;
                MoveObstackleOpenSignal.Trigger(obstackleIndex);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag))
            {
                _renderer.material.color = Color.white;
                MoveObstackleCloseSignal.Trigger(obstackleIndex);
            }
        }
    }
}
