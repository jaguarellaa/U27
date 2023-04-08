using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerPosition.position;
    }
}
