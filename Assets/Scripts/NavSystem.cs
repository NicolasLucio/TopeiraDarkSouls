using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavSystem : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform objective;
    public bool isAlive = true;
    public GameObject primarySystemObj;
    public PrimarySystem primaryScript;
    public Animator anin;
    
    void Start()
    {
        anin = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        isAlive = true;        
        primarySystemObj = GameObject.FindGameObjectWithTag("System");
        primaryScript = primarySystemObj.GetComponent<PrimarySystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!navAgent.isOnNavMesh)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(collision.gameObject.tag);
            //primaryScript.scoreNumber++;
            //StartCoroutine(Deathtimer());                       
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            primaryScript.GameOver();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Estruturas"))
        {
            if (isAlive == true)
            {
                navAgent.SetDestination(objective.position);
            }            
        }
    }
    public void finishattack()
    {
        StartCoroutine("Idletimer");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& isAlive)
        {
            anin.SetTrigger("attacking");
            isAlive = false;
        }
    }
    public IEnumerator Deathtimer()
    {
        isAlive = false;
        navAgent.ResetPath();
        this.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        Debug.Log("Death Timer on");
    }

    IEnumerator Idletimer()
    {
        yield return new WaitForSeconds(1f);
        isAlive = true;
    }

    public void GetAttacked()
    {
        Debug.Log("Foi Atacado");
        // myRb.AddForce(-transform.forward * forceSpeed, ForceMode.Impulse);
        this.gameObject.GetComponent<Rigidbody>().AddForce(-this.transform.forward * 100.0f, ForceMode.Impulse);
        StartCoroutine(Idletimer());
        StartCoroutine(Deathtimer());
    }
}
