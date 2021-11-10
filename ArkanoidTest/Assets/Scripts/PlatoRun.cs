using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoRun : MonoBehaviour
{
    //public float speed; 
    public float rightEdge;
    public float leftEdge;
    

    void Update()
    {
        if (GameBehavior.instance.currentGameState == GameState.inGame)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    

                    if (pos.x > leftEdge && pos.x < rightEdge)
                    { 
                        pos.y = this.transform.position.y;
                        this.transform.position = pos;
                    }
                }
            }

            /*transform.Translate(touch.position * Time.deltaTime * speed);

            float horizontal = Input.GetAxis("Horizontal");

            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector2(leftEdge, transform.position.y);
            }

            if (transform.position.x > rightEdge)
            {
                transform.position = new Vector2(rightEdge, transform.position.y);
            }*/
        }

    }
}
