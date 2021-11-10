using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPrefabLevelII : MonoBehaviour
{
    public GameObject block;
    public float startPosX;
    public float startPosY;
    public float outX;
    public float outY;
    private GameObject[,] grid;

    void Start()
    {

        grid = new GameObject[10, 10];

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                grid[x, y] = RegisterIcon(new CCell(x, y));
            }
        }
    }
    private GameObject RegisterIcon(CCell pos)
    {
        GameObject gameObject = Instantiate(block) as GameObject;
        gameObject.transform.SetParent(this.transform);
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.position = GetIconCenterByCell(pos);
        return gameObject;
    }

    public Vector3 GetIconCenterByCell(CCell cell)
    {
        return new Vector3(
            startPosX + cell.y * outX,
            startPosY + cell.x * outY,
            this.transform.position.z
        );
    }
    public class CCell
    {
        public int x;
        public int y;
        public CCell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}