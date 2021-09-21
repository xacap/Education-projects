using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGeneerator : MonoBehaviour
{
    

    void Start()
    {
        GameObject prefab = Resources.Load("Brx") as GameObject;

        for (int i = 0; i < 10; i++)
        {
            for (int height = 0; height < 3; height++)
            {
                GameObject brx = Instantiate(prefab) as GameObject;
                brx.transform.position = new Vector2(transform.position.x + i * 0.56f, transform.position.y + height * 0.4f);

            }
        }
    }

}
