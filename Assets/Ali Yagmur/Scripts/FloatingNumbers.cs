using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingNumbers : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyTime = 1.5f;
    public float number;
    public TextMeshPro text;

    private void Start()
    {
        number = transform.position.y;
        int myInt = Mathf.RoundToInt(number);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        text = GetComponent<TextMeshPro>();

        if (myInt > 0)
        {
            text.text = " +" + myInt.ToString();
        }
        else
        {
            text.text = myInt.ToString();
        }

        Destroy(gameObject, destroyTime);
    }


    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}

