using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public int whichBullet;

    void Start()
    {
        if(whichBullet == 2)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
        }
        StartCoroutine(BulletSinceWake());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Estruturas"))
        {            
            this.GetComponent<ParticleSystem>().Play();
            StartCoroutine(BulletTimeToDie());
        }       
    }

    IEnumerator BulletTimeToDie()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    IEnumerator BulletSinceWake()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        BulletTimeToDie();
    }
}
