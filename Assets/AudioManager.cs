using System;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Volume Setting----------")]
    [Range(0f, 1f)] public float backgroundVolume = 0.5f;

    [Header("----------SFX Setting----------")]
    [Range(0f, 1f)] public float SFXVolume = 1f;

    [Header("----------Audio Clip----------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip flip;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip attack;
    public AudioClip hurt;
    public AudioClip lose;
    public AudioClip win;

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

    public void StopSFX()
    {
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}