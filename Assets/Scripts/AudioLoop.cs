using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    public AudioClip introClip;

    // https://andrewmushel.com/articles/looping-music-in-unity/
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(introClip);
        source.PlayScheduled(AudioSettings.dspTime + introClip.length);
    }
}
