using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawMap : MonoBehaviour
{
    [SerializeField]
    private int Size = 5;

    public Box BoxMap;

    private Box Root, NextBox;
    
    public Box[][] ListBox;

    public Box[] GameWays;

    void Start()
    {
        ListBox = new Box[Size][];
        for (int i = 0; i < Size; i++)
        {
            ListBox[i] = new Box[Size];
        }
        
        CreateMap();
        GetFirstRoot();
        //RamdomPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                Next.GetComponent<Renderer>().enabled = false;
                ListBox[x][y] = Next;
                if (x >= 3 && x <= 11)
                    if(y >= 3 && y <= 11)
                        Next.ValidBox = true;
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

    private void RamdomPosition()
    {
        while(NextBox != null)
            NextBox = AvailableArea.NextBox(NextBox);
    }

    private void GetFirstRoot()
    {
        System.Random random = new System.Random();
        int x, y;
        do
        {
            x = random.Next(3, 12);
            y = random.Next(3, 12);
        }
        while (AvailableArea.CheckArea(x, y));
        Root = ListBox[x][y];
        NextBox = AvailableArea.NextBox(ListBox[x][y]);
        ActiveBox(Root);
        while(NextBox != null)
            NextBox = AvailableArea.NextBox(NextBox);
    }

    private void ActiveBox(Box box)
    {
        box.GetComponent<Renderer>().enabled = true;
    }

}
