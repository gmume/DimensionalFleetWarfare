using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string ShipName { get; private set; }
    public int PartsCount { get; private set; }
    private bool[] partDamaged;
    public int Dimension { get; private set; }
    public int X { get; private set; }
    public int Z { get; private set; }
    public Directions Direction { get; set; }

public void InitiateShip(int shipNr)
    {
        PartsCount = shipNr + 2;
        ShipName = "ship" + PartsCount.ToString();
        partDamaged = new bool[PartsCount];

        for (int i = 0; i < shipNr; i++)
        {
            partDamaged[i] = false;
        }

        Dimension = 0;
        X = shipNr;
        Direction = Directions.North;
    }

    public void QuaterTurnRight()
    {
        Quaternion quaterTurn = Quaternion.Euler(Vector3.forward * 90);
        if (Direction == Directions.North)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.East;
        }   
        else if (Direction == Directions.South)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.West;
        } 
        else if (Direction == Directions.East)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.South;
        }  
        else if (Direction == Directions.West)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.North;
        }  
    }

    public void QuaterTurnLeft()
    {
        Quaternion quaterTurn = Quaternion.Euler(Vector3.forward * 90);
        if (Direction == Directions.North)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.West;
        }
        else if (Direction == Directions.South)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.East;
        }
        else if (Direction == Directions.East)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.North;
        }
        else if (Direction == Directions.West)
        {
            this.transform.rotation = quaterTurn;
            Direction = Directions.South;
        }
    }

    public bool[] GetDamagedParts()
    {
        return partDamaged;
    }
}
