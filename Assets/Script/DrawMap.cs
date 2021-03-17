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
    private Box MainCopy; 
    void Start()
    {
        RamdomPosition(BoxMap);
        CreateMap();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMap()
    {
        if(BoxMap.Top == null)
        {
            BoxMap.Top = AddTop(BoxMap, Size);
        }
        //if (BoxMap.Bottom == null)
        //{
        //    Box Bottom = Instantiate<Box>(BoxMap);
        //    Bottom.Root.transform.position += Vector3.back * 1;
        //    BoxMap.Bottom = Bottom;
        //}
        //if (BoxMap.Left == null)
        //{
        //    Box Left = Instantiate<Box>(BoxMap);
        //    Left.Root.transform.position += Vector3.left * 1;
        //    BoxMap.Left = Left;
        //}
        //if (BoxMap.Right == null)
        //{
        //    Box Right = Instantiate<Box>(BoxMap);
        //    Right.Root.transform.position += Vector3.right * 1;
        //    BoxMap.Right = Right;
        //}
    }


    public Box AddTop(Box Root, int Count)
    {
        if(Count == 0)
        {
            Root.Left = AddLeft(Root, 5);
            return Root;
        }
        else
        {
            Box Top = Instantiate<Box>(Root);
            Top.transform.position += Vector3.forward * 1;
            Top.Bottom = Root;
            return AddTop(Top, Count - 1);
        }
            
    }

    public Box AddLeft(Box Root, int Count)
    {
        if (Count == 0)
        {
            Root.Bottom = AddBottom(Root, 5);
            return Root;
        }
        else
        {
            Box Left = Instantiate<Box>(Root);
            Left.transform.position += Vector3.left * 1;
            Left.Right = Root;
            return AddLeft(Left, Count - 1);
        }

    }

    public Box AddRight(Box Root, int Count)
    {
        if (Count == 0)
        {
            return Root;
        }
        else
        {
            Box Right = Instantiate<Box>(Root);
            Right.transform.position += Vector3.right * 1;
            Right.Left = Root;
            return AddRight(Right, Count - 1);
        }

    }

    public Box AddBottom(Box Root, int Count)
    {
        if (Count == 0)
        {
            Root.Right = AddRight(Root, 5);
            return Root;
        }
        else
        {
            Box Bot = Instantiate<Box>(Root);
            Bot.transform.position += Vector3.back * 1;
            Bot.Top = Root;
            return AddBottom(Bot, Count - 1);
        }

    }

    private void RamdomPosition(Box Root)
    {
        System.Random random = new System.Random();
        Root.transform.position = new Vector3(random.Next(1,10), random.Next(1, 10), Root.Root.transform.position.z);
    }


}
