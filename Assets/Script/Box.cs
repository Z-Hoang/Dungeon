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
    }

    public bool isActiveTop;
    public bool isActiveBottom;
    public bool isActiveLeft;
    public bool isActiveRight;

    public bool isCheck = false;

    public Box Top { get => top; set => top = value; }
    public Box Bottom { get => bottom; set => bottom = value; }
    public Box Left { get => left; set => left = value; }
    public Box Right { get => right; set => right = value; }

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

}
