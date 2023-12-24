using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundSource;
    public AudioSource soundsEffect;

    public AudioClip backgroundClip;
    public AudioClip runClip;
    public AudioClip jumpClip;

    void Start()
    {
        backgroundSource.clip = backgroundClip;
        backgroundSource.Play();
        soundsEffect.clip = runClip;
        soundsEffect.loop = true;
        soundsEffect.pitch = 1.2f;
        soundsEffect.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        soundsEffect.PlayOneShot(clip);
        RestartRunning();
    }

    public void RestartRunning()
    {
        soundsEffect.clip = runClip;
        soundsEffect.loop = true;
        soundsEffect.pitch = 1.2f;
        soundsEffect.Play();
    }
}
