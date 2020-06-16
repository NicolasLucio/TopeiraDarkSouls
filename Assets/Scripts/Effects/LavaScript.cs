using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public float velocity = 0.5f;
    private float textDesl = 0.0f;
    private Renderer renderizer;

    void Start()
    {
        renderizer = GetComponent<Renderer>();
    }

    void Update()
    {
        textDesl = textDesl + Time.deltaTime * velocity;
        renderizer.material.mainTextureOffset = new Vector2(-textDesl, 0);
        if (textDesl >= 5.0f)
        {
            textDesl = 0.0f;
        }
    }    
}

