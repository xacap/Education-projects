using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevelII : MonoBehaviour
{
    public static PlayerControllerLevelII instance;
    public Rigidbody2D rb2d;
    public float speed = 5f;
    public Transform plato;
    public bool inPlay;
    public float thrust;
    public AudioClip barSound;
    public AudioClip platoSound;
    public AudioClip boxSound;

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
    void Update()
    {
        if (GameBehavior.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0) && !inPlay)
            {
                inPlay = true;
                Jump();
            }
            else if (!inPlay)
            {
                transform.position = plato.position;
            }
        }
    }
    void FixedUpdate()
    {
        Destroy();
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
        thrust = cSpeed * ((cSpeed / 5) * rb2d.mass);
        rb2d.AddForce(rb2d.velocity.normalized * thrust);
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(0f, 1f) * speed;
    }

    public void Lose()
    {
        GameBehavior.instance.GameOver();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (collision.gameObject.tag == "bar")
        {

            audio.PlayOneShot(barSound);
        }
        if (collision.gameObject.tag == "bul")
        {

            audio.PlayOneShot(barSound);
        }
        if (collision.gameObject.tag == "box")
        {

            audio.PlayOneShot(boxSound);
        }
        if (rb2d.velocity.magnitude > 1f && collision.gameObject.tag == "plato")
        {

            audio.PlayOneShot(platoSound);
        }
    }
}