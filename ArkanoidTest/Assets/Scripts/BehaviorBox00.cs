using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorBox00 : MonoBehaviour
{
    public int healthBox;

    public GameBehavior gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthBox -= 1;           
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        healthBox = Random.Range(1,4);
    }

    void Update()
    {
        State();
    }

 
    public void State()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (healthBox == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        else if (healthBox == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }

        else if (healthBox == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        else if (healthBox == 0)
        {
            gameManager.CoundDestroyBlock += 1;
            Destroy(gameObject);
            gameManager.Score += 10;
        }
    }

 }
