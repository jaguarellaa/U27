using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips;  // List of audio clips to play

    private AudioSource audioSource;   // Reference to the audio source component

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayAudio(0);
    }

    public void PlayAudio(int index)
    {
        if (index < 0 || index >= audioClips.Count)
        {
            Debug.LogError("Invalid audio clip index.");
            return;
        }
        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

}
