using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrimarySystem : MonoBehaviour
{
    public AudioSource cameraAudioSource;
    public AudioClip deathSound;
    public GameObject gameOverCanvas;
    public AudioSource gameMusic;

    public Slider lifeSlider;
    public float characterLife;
    private float initialLife;

    public Slider manaSlider;
    public float characterMana = 10.0f;

    public int guaravitas = 3;
    public TextMeshProUGUI guaravitaText;


    //besteiras abaixo
    public GameObject glubObject;

    void Awake()
    {
        gameOverCanvas.SetActive(false);
        Cursor.visible = false;
        gameMusic.Play();
        lifeSlider.value = characterLife;
        initialLife = characterLife;
        manaSlider.value = 10.0f;

        guaravitaText.text = guaravitas.ToString();

        StartCoroutine(ManaRegen());
    }

    public void GameOver()
    {
        StartCoroutine(GOTimer());
    }

    public void CalculateLife(float howMuch, bool damage, bool withGuaravita)
    {
        if (damage == true)
        {
            characterLife = characterLife - howMuch;
            lifeSlider.value = characterLife;
            if (characterLife <= 0.0f)
            {
                GameOver();
            }
        }
        else
        {
            characterLife = characterLife + howMuch;
            if (characterLife > initialLife)
            {
                characterLife = initialLife;
            }
            if (withGuaravita == true)
            {
                StartCoroutine(EffectTimer(0.25f, 1));                
                guaravitas--;
                guaravitaText.text = guaravitas.ToString();
            }
            lifeSlider.value = characterLife;
            
        }        
    }

    public void CalculateMana(bool more)
    {
        if (more == true)
        {
            if (characterMana < 10.0f)
            {
                characterMana++;
            }            
        }
        else
        {
            if (characterMana != 0.0f)
            {
                characterMana--;
            }
        }
        manaSlider.value = characterMana;
    }

    public void BonfireAction()
    {
        StartCoroutine(EffectTimer(1.5f, 2));
        guaravitas = 3;
        guaravitaText.text = guaravitas.ToString();

    }

    IEnumerator GOTimer()
    {
        gameMusic.Stop();
        cameraAudioSource.clip = deathSound;
        gameOverCanvas.SetActive(true);
        cameraAudioSource.Play();
        yield return new WaitForSecondsRealtime(1.5f);
        Scene tempSceneActive = SceneManager.GetActiveScene();
        SceneManager.LoadScene(tempSceneActive.name);
    }

    IEnumerator ManaRegen()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(20.0f);
            if (characterMana != 10.0f)
            {                
                CalculateMana(true);
            }            
        }
    }

    IEnumerator EffectTimer(float timer, int whichEffect)
    {
        if (whichEffect == 1)
        {
            glubObject.GetComponent<TextMeshProUGUI>().text = "GLUB!";
        }
        else if (whichEffect == 2)
        {
            glubObject.GetComponent<TextMeshProUGUI>().text = "GLUB RESTORED";
        }
        glubObject.SetActive(true);
        yield return new WaitForSecondsRealtime(timer);
        glubObject.SetActive(false);
    }
}
