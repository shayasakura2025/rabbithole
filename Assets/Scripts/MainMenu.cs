using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    public AudioClip buttonSound;
    new AudioSource audio;
    public void PlayGame() {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        StartCoroutine(waitForSound());
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        StartCoroutine(waitForSound());
        Application.Quit();
    }

    public IEnumerator waitForSound()
    {
        while (audio.isPlaying)
            yield return null;

    }
}
