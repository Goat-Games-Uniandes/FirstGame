using System;
using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(Keyboard.current.dKey.isPressed)
        {
            pos.x += 5.0f * Time.deltaTime;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            pos.x -= 5.0f * Time.deltaTime;
        }
        transform.position = pos;

        Clamp();
    }

    void Clamp()
    {
    Vector3 pos = transform.position;
    CircleCollider2D collider = GetComponent<CircleCollider2D>();
    float clamp = collider.radius;

    float leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + clamp;
    float rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - clamp;

    pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);

    transform.position = pos;
    }
    
}
