using System;

public class Class1
{
    public GameObject[,] icons;


    protected void CreateIcons()
    {

        icons = new GameObject[height, width];

        for (int row = 0; row < height; row++)
        {

            for (int col = 0; col < width; col++)
            {

                icons[row, col] = RegisterIcon(new CCell(row, col));

            }

        }

    }

    private GameObject RegisterIcon(CCell position)
    {
        GameObject gameObject = Instantiate(prefab) as GameObject;
        gameObject.transform.SetParent(this.transform);
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.position = GetIconCenterByCell(position);


        return gameObject;
    }



    public Vector3 GetIconCenterByCell(CCell cell)
    {
        Vector3 startPos;
        Vector2 offset;

        return new Vector3(
            startPos.x + cell.col * offset.x,
            startPos.y + cell.row * offset.y,
            this.transform.position.z
        );
    }
}
