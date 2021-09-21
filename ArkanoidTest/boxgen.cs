using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxgen : MonoBehaviour
{

    public GameObject[] Box = new GameObject[3];

    void Start()
    {
        for (int i = 0; i < Size; i++)
        {
            Box[i] = GameObject.Instantiate(Resources.Load("")) as GameObject;
            //var element = Box[Random.Range(0, Box.Length)];

            Box[i].transform.position = new Vector2(transform.position.x + i * 0.56f, transform.position.y + height * 0.4f);
        }
    }

    
}
