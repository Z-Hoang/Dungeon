using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Box Top { get; set; }
    public Box Bottom { get; set; }
    public Box Left { get; set; }
    public Box Right { get; set; }

    public bool isActiveTop { get; set; }
    public bool isActiveBottom { get; set; }
    public bool isActiveLeft { get; set; }
    public bool isActiveRight { get; set; }

    public void AddTop(Box NextTop)
    {
        if (Top == null && isActiveTop)
            Top = NextTop;
    }

    public void AddLeft(Box NextLeft)
    {
        if (Left == null && isActiveLeft)
            Left = NextLeft;
    }

    public void AddRight(Box NextRight)
    {
        if (Right == null && isActiveRight)
            Right = NextRight;
    }

    public void AddBottom(Box NextBottom)
    {
        if (Bottom == null && isActiveBottom)
            Bottom = NextBottom;
    }

}
