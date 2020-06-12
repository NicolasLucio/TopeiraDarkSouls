using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSystem : MonoBehaviour
{
    public int whichMagic;    
    void Start()
    {
        StartCoroutine(SelfDestroy());
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Acertou");
            collision.gameObject.GetComponent<NavSystem>().GetAttacked();        
            this.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            Debug.Log("Errou");            
            this.GetComponent<ParticleSystem>().Stop();
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(this.gameObject);
    }

    
}
