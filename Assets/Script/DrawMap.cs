using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawMap : MonoBehaviour
{
    // Start is called before the first frame update
    public int Size = 5;
    public Box BoxMap;
    //public GameObject Cube;
    public Box[][] ListBox;

    public Box[] GameWays;

    void Start()
    {
        ListBox = new Box[Size][];
        for (int i = 0; i < Size; i++)
        {
            ListBox[i] = new Box[Size];
        }
        RamdomPosition(BoxMap);
        CreateMap();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateMap()
    {
        MatrixBox(Size, BoxMap);

    }

    public void MatrixBox(int n, Box box)
    {
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                Box Next = Instantiate<Box>(box);
                Next.transform.position = new Vector3(x, 0, y);
                Next.name = x + "," + y;
                Next.transform.SetParent(transform);

                ListBox[x][y] = Next;
                if (y != 0)
                {
                    Next.AddLeft(ListBox[x][y - 1]);
                }

                if (x != 0)
                {
                    Next.AddTop(ListBox[x - 1][y]);
                }

            }
        }
    }


    public void AddBox()
    {
        System.Random random = new System.Random();


    }

    private void RamdomPosition(Box Root)
    {


    }

    private void GetFirstRoot()
    {
        System.Random random = new System.Random();
        int x = random.Next(4, 12);
        int[] lstIdex = { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        if (x >= 7 || x > 12)
        {

        }
    }
}
