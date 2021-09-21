using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatoRun : MonoBehaviour
{
    public float speed; 
    public float rightEdge;
    public float leftEdge;

    void Update()
    {
        if (GameBehavior.instance.currentGameState == GameState.inGame)
        {
            float horizontal = Input.GetAxis("Horizontal");

            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector2(leftEdge, transform.position.y);
            }
            if (transform.position.x > rightEdge)
            {
                transform.position = new Vector2(rightEdge, transform.position.y);
            }
        }
        
    }
}
