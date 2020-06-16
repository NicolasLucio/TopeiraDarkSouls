using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireSystem : MonoBehaviour
{
    public PrimarySystem primaryScript;

    public bool canRestoreGuaravita = false;
    void FixedUpdate()
    {
        if (canRestoreGuaravita == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //BonfireAction();
                primaryScript.BonfireAction();
            }
        }        
    }    

    private void OnTriggerEnter(Collider other)
    {
        canRestoreGuaravita = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canRestoreGuaravita = false;
    }
}
