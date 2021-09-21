using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatoRun : MonoBehaviour
{
    Rigidbody2D hardbody2d;
    public float rightEdge;
    public float leftEdge;

    void Start()
    {
        hardbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = hardbody2d.position;
        position.x = position.x + 0.2f * horizontal;

        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        if (transform.position.x > leftEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }
    }
}
