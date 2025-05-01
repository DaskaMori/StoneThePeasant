using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private float audioProgress = 0f;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        audioProgress += audioSource.time;
    }

    public void ChangeAudio()
    {
        float frozenProgress = audioProgress;
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    
}
