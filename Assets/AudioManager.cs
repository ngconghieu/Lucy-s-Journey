using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource stopSource;

    [Header("----------Volume Setting----------")]
    [Range(0f, 1f)] public float backgroundVolume = 0.5f;

    [Header("----------SFX Setting----------")]
    [Range(0f, 1f)] public float SFXVolume = 1f;


    [Header("----------Audio Clip----------")]
    public AudioClip background;
    [Header("----------Audio Player----------")]
    public AudioClip death;
    public AudioClip flip;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip attack;

    private void Start()
    {
        PlayMusic(background);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = backgroundVolume;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.volume = SFXVolume;
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        if (stopSource.isPlaying)
        {
            stopSource.Stop();
        }
    }

    internal void StopSFX()
    {
        throw new NotImplementedException();
    }
}
