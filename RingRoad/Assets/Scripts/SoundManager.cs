using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public static SoundManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
    
}
