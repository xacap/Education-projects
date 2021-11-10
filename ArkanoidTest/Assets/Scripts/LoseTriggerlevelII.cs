using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTriggerlevelII : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerControllerLevelII.instance.Lose();
        }
    }
}
