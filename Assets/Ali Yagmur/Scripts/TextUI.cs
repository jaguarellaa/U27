using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] GameObject messageBox;
    [SerializeField] TextMeshProUGUI infoTextBox;

    [SerializeField] string theMessage;

    [SerializeField] float duration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowText(duration));
        }
    }

    IEnumerator ShowText(float time)
    {
        infoTextBox.text = theMessage;
        messageBox.SetActive(true);
        yield return new WaitForSeconds(time);
        messageBox.SetActive(false);
        Destroy(this.gameObject);
    }
}
