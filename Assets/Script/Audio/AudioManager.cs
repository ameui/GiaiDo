using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // âm nhạc sẽ lặp lại
        musicSource.loop = true;
    }
    private void Start()
    {
        PlayMusic(musicSource.clip);
    }
    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource.clip != musicClip)
        {
            musicSource.Stop();
            musicSource.clip = musicClip;
        }
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }
}
