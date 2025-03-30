using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenManager : MonoBehaviour
{
    public SoundManager soundManager;

    void Start()
    {
        StartCoroutine(playWinSound());
    }

    public IEnumerator playWinSound()
    {
        yield return new WaitForSeconds(0.5f);
        soundManager.playWinSound();
    }
}
