using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrimarySystem : MonoBehaviour
{
    public AudioSource cameraAudioSource;
    public AudioClip deathSound;
    public GameObject gameOverCanvas;
    public AudioSource gameMusic;
    void Awake()
    {
        gameOverCanvas.SetActive(false);
        Cursor.visible = false;
        gameMusic.Play();
    }

    public void GameOver()
    {
        StartCoroutine(GOTimer());
    }

    IEnumerator GOTimer()
    {
        gameMusic.Stop();
        cameraAudioSource.clip = deathSound;
        gameOverCanvas.SetActive(true);
        cameraAudioSource.Play();
        yield return new WaitForSecondsRealtime(1.5f);
        //load screen
        SceneManager.LoadScene("TopeiraScene");
    }
}
