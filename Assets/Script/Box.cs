using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{

    private Box top;
    private Box bottom;
    private Box left;
    private Box right;
    private int x, y;
    private bool validBox;
    public Box()
    {
        Top = null;
        Bottom = null;
        Left = null;
        Right = null;
        
        this.isActiveTop = true;
        this.isActiveBottom = true;
        this.isActiveLeft = true;
        this.isActiveRight = true;
        validBox = false;
    }

    public bool isActiveTop;
    public bool isActiveBottom;
    public bool isActiveLeft;
    public bool isActiveRight;

    public bool ValidBox { get => validBox; set => validBox = value; }
    public Box Top { get => top; set => top = value; }
    public Box Bottom { get => bottom; set => bottom = value; }
    public Box Left { get => left; set => left = value; }
    public Box Right { get => right; set => right = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    

    public void AddTop(Box NextTop)
    {
        if (Top == null && isActiveTop)
        {
            Top = NextTop;
            NextTop.Bottom = this;
            isActiveTop = !isActiveTop;
            NextTop.isActiveBottom = !NextTop.isActiveBottom;
        }
            
    }

    public void AddLeft(Box NextLeft)
    {
        if (Left == null && isActiveLeft)
        {
            Left = NextLeft;
            NextLeft.Right = this;
            isActiveLeft = !isActiveLeft;
            NextLeft.isActiveRight = !NextLeft.isActiveRight;
        }
    }

    public void AddRight(Box NextRight)
    {
        if (Right == null && isActiveRight)
        {
            Right = NextRight;
            NextRight.Left = this;
            isActiveRight = !isActiveRight;
            NextRight.isActiveLeft = !NextRight.isActiveLeft;
        }
    }

    public void AddBottom(Box NextBottom)
    {
        if (Bottom == null && isActiveBottom)
        {
            Bottom = NextBottom;
            NextBottom.Top = this;
            isActiveBottom = !isActiveBottom;
            NextBottom.isActiveTop = !NextBottom.isActiveTop;
        }
    }

    public bool InvalidBox(Box Previous)
    {
        if (Previous.X == X)
        {
            Previous.Left.ValidBox = Previous.Right.ValidBox = false;
            if (Previous.Y - Y > 0)
                Previous.Top.Left.ValidBox = Previous.Top.Right.ValidBox = false;
            else
                Previous.Bottom.Left.ValidBox = Previous.Bottom.Right.ValidBox = false;

        }
        else
        {
            Previous.Bottom.ValidBox = Previous.Top.ValidBox = false;
            if (Previous.X - X > 0)
                Previous.Left.Top.ValidBox = Previous.Left.Bottom.ValidBox = false;
            else
                Previous.Right.Top.ValidBox = Previous.Right.Bottom.ValidBox = false;
        }
        ValidBox = false;
        ActiveBox();
        return true;
    }

    private void ActiveBox()
    {
        GetComponent<Renderer>().enabled = true;
    }


}
