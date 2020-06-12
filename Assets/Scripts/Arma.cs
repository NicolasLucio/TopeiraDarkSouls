using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private GameObject arma;
    public int municao;
    public int municaopente;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void fire()
    {
        if (municaopente > 0)
        {
            municaopente--;
        }

    }

    public void reloader()
    {
        municaopente = 30;
    }
}

