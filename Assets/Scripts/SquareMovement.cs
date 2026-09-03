using UnityEngine;
using UnityEngine.Android;

public class SquareMovement : MonoBehaviour
{
    private int movement = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += 10.0f * Time.deltaTime * movement * Vector3.up;
        transform.position = pos;

        Clamp();
    }

    void Clamp()
    {
    Vector3 pos = transform.position;
    BoxCollider2D collider = GetComponent<BoxCollider2D>();
    float clamp = collider.size.y / 2;

    float topLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - clamp;
    float bottomLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + clamp;

    pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);

    if (pos.y >= topLimit)
    {
        movement = -1;
    }
    else if (pos.y <= bottomLimit)
    {
        movement = 1;
    }

    transform.position = pos;
    }
}
