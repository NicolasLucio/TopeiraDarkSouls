using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [Space(10)]
    public CharacterController chtr;
    [Space(10)]
    public float playerSpeed;
    [Space(10)]
    public Vector3 movement, rotation;

    void Start()
    {
        if (!chtr)
        {
            chtr = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        movement = Vector3.zero;
        rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * playerSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement += -transform.forward * playerSpeed;
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            movement += -transform.right * playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right * playerSpeed;
        }

        rotation.y = Input.GetAxis("Mouse X");

        chtr.SimpleMove(movement);
        transform.Rotate(rotation);
    }
}