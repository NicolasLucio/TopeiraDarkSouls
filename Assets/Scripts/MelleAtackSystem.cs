using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAtackSystem : MonoBehaviour
{
    private bool atackAnimation = false;    
    private bool triggerLoop;
    public AudioSource atacksound;
   
    void Start()
    {
        atackAnimation = false;
    }
    
    void Update()
    {
        
    }

    public void AttackMade()
    {
        StartCoroutine(AttackTimer());
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        atackAnimation = true;        
        yield return new WaitForSecondsRealtime(1.0f);
        atackAnimation = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo") && atackAnimation == true && triggerLoop == false)
        {            
            Debug.Log("Eita porra");                     
            //temporaryEnemy = other.gameObject
            other.gameObject.GetComponent<NavSystem>().GetAttacked();
            if (!atacksound.isPlaying)
            {
                atacksound.Play();
            }            
            triggerLoop = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            triggerLoop = false;
        }
    }
}
