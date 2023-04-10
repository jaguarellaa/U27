using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PK
{
    public class Loading : MonoBehaviour
    {
        void Start()
        {
            Invoke(nameof(loadNext), 2f);
        }

      
        public void loadNext()
        {
            SceneManager.LoadScene(1);
        }
    }
}
