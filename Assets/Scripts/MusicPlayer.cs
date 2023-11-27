using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] introClips;
    public AudioClip[] loopClips;

    private AudioSource source;
    private int currentTrack = -1;

    // based on https://andrewmushel.com/articles/looping-music-in-unity/
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayTrack(0);
    }

    public void PlayTrack(int track)
    {
        if (track == currentTrack)
        {
            return;
        }

        if (source.isPlaying)
        {
            source.Stop();
        }

        currentTrack = track;

        if (track == -1)
        {
            return;
        }

        AudioClip introClip = introClips[track];
        AudioClip loopClip = loopClips[track];

        source.clip = loopClip;
        source.PlayOneShot(introClip);
        source.PlayScheduled(AudioSettings.dspTime + introClip.length);
    }
}
