using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlockAnimatedSound : MonoBehaviour
{
    public bool canJump = false;

    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    public void cueJumpSound()
    {
        if (canJump)
            soundManager.playJumpSound();
        
    }
}
