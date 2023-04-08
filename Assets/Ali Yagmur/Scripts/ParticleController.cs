using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyInTime());
    }

    IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
