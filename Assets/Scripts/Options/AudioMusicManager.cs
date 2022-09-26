using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicManager : MonoBehaviour
{
    public static AudioMusicManager instance;
    public AudioSource musicSource;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public bool[] musicOnPlay;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic1();
        musicSource.Play(0);
    }

    public void PlayMusic1()
    {
        musicSource.clip = music1;
    }
    public void PlayMusic2()
    {
        musicOnPlay[0] = false;
        musicSource.clip = music2;
        musicSource.Play(0);
    }
    public void PlayMusic3()
    {
        musicOnPlay[1] = false;
        musicSource.clip = music3;
        musicSource.Play(0);
    }
    public void PlayMusic4()
    {
        musicOnPlay[2] = false;
        musicSource.clip = music4;
        musicSource.Play(0);
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

}
