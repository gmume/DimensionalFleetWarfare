using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Ship")]

public class Ship : ScriptableObject
{
    private string shipName;
    private int partsCount;
    private bool[] partDamaged;

    private int dimension;
    private int x;
    private int y;
    private Directions direction;

    public void InitiateShip(int countParts)
    {
        shipName = "ship" + (countParts + 2).ToString();
        partsCount = countParts;

        for (int i = 0; i < partsCount; i++)
        {
            partDamaged[i] = false;
        }

        dimension = 0;
        direction = Directions.North;
    }

    public void SetX(int newX)
    {
        x = newX;
    }

    public int GetX()
    {
        return x;
    }

    public void SetY(int newY)
    {
        y = newY;
    }

    public int GetY()
    {
        return y;
    }

    public void QuaterTurn()
    {
        if (direction == Directions.North)
            direction = Directions.East;
        else if (direction == Directions.South)
            direction = Directions.West;
        else if (direction == Directions.East)
            direction = Directions.South;
        else if (direction == Directions.West)
            direction = Directions.North;
    }

    public int getDimension()
    {
        return dimension;
    }
}
