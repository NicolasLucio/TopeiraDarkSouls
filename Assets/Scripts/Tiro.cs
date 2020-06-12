using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public GameObject arma;
    public Arma scriptarma;

    void Start()
    {
        scriptarma = arma.GetComponent<Arma>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }
    
    void fire()
    {
        scriptarma.fire();
    }
}