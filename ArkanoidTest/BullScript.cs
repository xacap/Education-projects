using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullScript : MonoBehaviour
{
    Rigidbody2D hardbody2d;

    void Start()
    {
        hardbody2d = GetComponent<Rigidbody2D>();

    }

    public void Poexali(Vector2 direction, float force)
    {
        hardbody2d.AddForce(direction * force);

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    if(Input.GetKeyDown(KeyCode.C))
    {
        Poexali();
    }
}
