using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPrefab : MonoBehaviour
{
   public GameObject[] box;


    public GameObject RandomBox()
    {
        GameObject newBox = new Random.Range(0, box.Length);
        return newBox;
    }

    
    private GameObject RegisterIcon()
    {
        GameObject gameObject = Instantiate(box) as GameObject;
        gameObject.transform.SetParent(this.transform);
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.position = GetIconCenterByCell(position);


        return gameObject;
    }

    protected void CreateIcons()
    {


        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Instantiate(RandomBox(), new Vector3(x, y, 0), Quaternion.identity);



            }

        }
    }


    void Start()
    {
        CreateIcons();


    }

}

