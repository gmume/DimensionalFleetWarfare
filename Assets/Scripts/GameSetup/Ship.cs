using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private string shipName;
    private int partsCount;
    private bool[] partDamaged;
    private int dimension;
    private int x;
    private int z;
    private Directions direction;

    public void InitiateShip(int shipNr)
    {
        partsCount = shipNr + 2;
        shipName = "ship" + partsCount.ToString();
        partDamaged = new bool[partsCount];

        for (int i = 0; i < shipNr; i++)
        {
            partDamaged[i] = false;
        }

        dimension = 0;
        SetX(shipNr);
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

    public void SetZ(int newZ)
    {
        z = newZ;
    }

    public int GetZ()
    {
        return z;
    }

    public void QuaterTurn()
    {
        Quaternion quaterTurn = Quaternion.Euler(Vector3.forward * 90);
        if (direction == Directions.North)
        {
            this.transform.rotation = quaterTurn;
            direction = Directions.East;
        }   
        else if (direction == Directions.South)
        {
            this.transform.rotation = quaterTurn;
            direction = Directions.West;
        } 
        else if (direction == Directions.East)
        {
            this.transform.rotation = quaterTurn;
            direction = Directions.South;
        }  
        else if (direction == Directions.West)
        {
            this.transform.rotation = quaterTurn;
            direction = Directions.North;
        }  
    }

    public string GetName()
    {
        return shipName;
    }

    public int GetDimension()
    {
        return dimension;
    }

    public bool[] GetDamagedParts()
    {
        return partDamaged;
    }
}
