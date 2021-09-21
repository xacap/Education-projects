using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    public Rigidbody2D rb2d;
    public bool inPlay;
    public Transform plato;
    public float speed;
    public float thrust;

    public GameBehavior gameManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb2d = GetComponent<Rigidbody2D>();
        transform.position = plato.position;
    }

    public void StartGame()
    {
        transform.position = plato.position;

    }

    void FixedUpdate()
    {
        Destroy();

        if (Input.GetMouseButtonDown(0) && !inPlay)
        {
            inPlay = true;
            rb2d.velocity = new Vector2(0f, 1f) * speed;
        }
    }
    void Update()
    {
        if (!inPlay)
        {
            transform.position = plato.position;
        }
    }

    public void Destroy()
    {
        if (GameBehavior.instance.CoundDestroyBlock >= 5)
        {

            SpeedUp();
            GameBehavior.instance.CoundDestroyBlock = 0;
        }
    }

    public void SpeedUp()
    {
        float cSpeed = rb2d.velocity.magnitude;
        thrust = cSpeed * ((cSpeed / 10) * rb2d.mass);
        rb2d.AddForce(rb2d.velocity.normalized * thrust);



    }

    public void Kill()
    {
        SceneManager.LoadSceneAsync("YouLose");
        //GameBehavior.instance.GameOver(); 

        /*  if (PlayerPrefs.GetInt("highscore", 0) < GameBehavior.instance.Score)
          {
              PlayerPrefs.SetInt("highscore", GameBehavior.instance.Score);
          }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Kill();
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("bottom"))
            {
                rb2d.velocity = Vector2.zero;
                inPlay = false;
            }
        }*/

}

