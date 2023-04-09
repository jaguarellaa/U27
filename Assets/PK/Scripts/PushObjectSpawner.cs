using PK.GameJam;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

namespace PK.GameJam
{
    public class PushObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Transform obstackleSpawnPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagContainer.PushObjectTag) || other.CompareTag(TagContainer.PlayerTag))
            {
                other.transform.position = obstackleSpawnPoint.position;
            }
        }
    }
}
