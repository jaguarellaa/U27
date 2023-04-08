using PK.GameJam;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

namespace PK
{
    public class PushObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Transform obstackleSpawnPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag))
            {
                other.transform.position = obstackleSpawnPoint.position;
            }
        }
    }
}
