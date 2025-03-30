using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip bunnySpawn;
    public AudioClip jumpSound;
    public AudioClip eatSound;

    new AudioSource[] audio;



    void Start()
    {
        audio = GetComponents<AudioSource>();   
    }

    public void playSpawnSound()
    {
        audio[0].clip = bunnySpawn;
        audio[0].Play();
    }

    public void playJumpSound() 
    {
        audio[2].clip = jumpSound;
        audio[2].Play();
    }

    public void playEatSound() 
    {
        audio[1].clip = eatSound;
        audio[1].Play();
    }
}
