using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeeed;
    public float mouseSensitivity;
    public float jumpingforce;
    public bool flipCamera = true;
    public bool runningJump = false;
    private Rigidbody rb;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement();
        rotationCam();
        jump();
    }

    void rotationCam()
    {
        float sensitivityY = Input.GetAxis("Mouse X");
        float sensitivityX = Input.GetAxis("Mouse Y");

        if (sensitivityY != 0)
        {
            sensitivityY = sensitivityY * mouseSensitivity;
            transform.Rotate(new Vector3(0, sensitivityY, 0));
        }

        if (sensitivityX != 0)
        {
            if (flipCamera)
            {
                sensitivityX = sensitivityX * -1;
            }

            sensitivityX = sensitivityX * mouseSensitivity;
            //Camera.main.transform.Rotate(new Vector3(sensitivityX, 0, 0));
        }
    }

    void jump()
    {
        if (runningJump == false)
        {
            if (Input.GetAxis("Jump") != 0)
            {
                rb.AddForce(transform.forward * jumpingforce);
                runningJump = true;
            }
        }
    }

    void movement(Vector3 movement = new Vector3())
    {
        float
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical");

        if (movement == Vector3.zero)
        {
            if (y != 0)
            {
                movement += y * transform.forward * playerSpeeed;
            }

            if (x != 0)
            {
                movement += x * transform.right * playerSpeeed;
            }
        }

        controller.SimpleMove(movement);
    }

    private void OnCollisionExit(Collision collision)
    {
        runningJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        runningJump = false;
    }
}
