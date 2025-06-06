using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    public AudioClip buttonSound;
    [SerializeField] GameObject creditsPage;
    [SerializeField] GameObject modeSelect;
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

    public void CreditsPage() {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        creditsPage.SetActive(true);
    }

    public void hideCreditsPage() {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        creditsPage.SetActive(false);
    }

    public void enableModeSelect()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        modeSelect.SetActive(true);
    }

    public void hideModeSelect()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = buttonSound;
        audio.Play();
        modeSelect.SetActive(false);
    }

    public IEnumerator waitForSound()
    {
        while (audio.isPlaying)
            yield return null;

    }
}
