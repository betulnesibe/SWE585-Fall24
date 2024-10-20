using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerScript : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Start playing the sound on start play on awake
    }

    void Update()
    {
        // 'm' button for play/pause
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pause the sound
            }
            else
            {
                audioSource.UnPause(); // Resume playing
            }
        }
    }
}
