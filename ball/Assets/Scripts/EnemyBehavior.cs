using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Color colorStart = Color.green;
    Color colorEnd = Color.yellow;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "infection")
        {
            StartCoroutine(SmoothAndDestroy());
            if (other.gameObject != null)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator SmoothAndDestroy()
    {
        float currTime = 0f;
        float time = 1.5f;
        rend.material.color = colorStart;
        do
        {
            rend.material.color = Color.Lerp(rend.material.color, colorEnd, currTime / time);
            currTime += Time.deltaTime;
            yield return null;

        } while (currTime <= time);

        Destroy(this.gameObject);
    }

}
