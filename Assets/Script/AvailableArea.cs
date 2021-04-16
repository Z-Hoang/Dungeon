using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AvailableArea
{
    [SerializeField]
    private static int MaxCenter = 8;

    [SerializeField]
    private static int MinCenter = 6;

    [SerializeField]
    private static int Top = 12;

    [SerializeField]
    private static int Bottom = 2;

    public static bool CheckArea(int x, int y)
    {
        bool CheckX = x < MinCenter && x > MaxCenter;
        bool CheckY = y < MinCenter && y > MaxCenter;
        
        return CheckX && CheckY;
    }

    public static bool CheckValidBox(Box CurrentBox, Box NextBox)
    {
        
        return true;
    }

    public static Box NextBox(Box CurrentBox)
    {
        System.Random random = new System.Random();
        Box NextBox = new Box();
        int RandomInt = -1;

        List<bool> BoolList = new List<bool>(new bool[]{
            CurrentBox.Top.ValidBox, CurrentBox.Right.ValidBox,
            CurrentBox.Bottom.ValidBox, CurrentBox.Left.ValidBox
        });

        List<int> ExceptionNumber = new List<int>();
        for (int i = 0; i < BoolList.Count; i++)
            if (BoolList[i])
                ExceptionNumber.Add(i);
        if (ExceptionNumber.Count == 0) return null;
        do
        {
            int randomNumber = random.Next(0, 4);
            for (int i = 0; i < ExceptionNumber.Count; i++)
            {
                if (randomNumber == ExceptionNumber[i])
                {
                    RandomInt = randomNumber;
                    break;
                }   
            }
        }
        while (RandomInt < 0);
        switch (RandomInt)
        {
            case 0:
                NextBox = CurrentBox.Top;
                break;
            case 1:
                NextBox = CurrentBox.Right;
                break;
            case 2:
                NextBox = CurrentBox.Bottom;
                break;
            case 3:
                NextBox = CurrentBox.Left;
                break;
        }
        NextBox.InvalidBox(CurrentBox);
        return NextBox;
    }

}
