using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK.GameJam
{
    public class PointREducer : MonoBehaviour
    {
        private SceneManagerScript _sceneManagerScript;
        private bool gameStarted;

        private void Awake()
        {
            _sceneManagerScript = GameObject.FindAnyObjectByType<SceneManagerScript>();
            
        }
        private void Start()
        {
            gameStarted= true;
        }
        private void OnEnable()
        {
            GameStartSignal.OnGameStarted += ToggleGameStarted;
        }
        private void OnDisable()
        {
            GameStartSignal.OnGameStarted -= ToggleGameStarted;
        }

        private void Update()
        {
        }
        private void ToggleGameStarted(bool value)
        {
            gameStarted= value;
        }
    }
    
    public static class GameStartSignal
    {
        public static event Action<bool> OnGameStarted;
        public static void Trigger(bool value)
        {
            OnGameStarted?.Invoke(value);
        }
    }
}
