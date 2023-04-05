using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string ShipName { get; private set; }
    public int Dimension { get; private set; }
    private Transform position;
    public int X { get; private set; }
    public int Z { get; private set; }
    public Directions Direction { get; set; }
    public int PartsCount { get; private set; }
    private bool[] partDamaged;

    public void Activate(PlayerScript player)
    {
        if (player.playerData.ActiveShip != this)
        {
            GetComponent<Renderer>().material.color = Color.black;
            Vector3 vectorUp = new(0f, 0.1f, 0f);
            GetComponent<Transform>().position += vectorUp;
            player.playerData.ActiveShip = this;
        }
        else
        {
            Debug.Log(ShipName + " is allready activated!");
        }
    }

    public void Deactivate(PlayerScript player)
    {
        GetComponent<Renderer>().material.color = Color.gray;
        Vector3 vectorDown = new(0f, -0.1f, 0f);
        GetComponent<Transform>().position += vectorDown;
        
        player.playerData.ActiveShip = null;
    }

    public void Move(int x, int y)
    {
        if (X + x < OverworldData.DimensionSize && Z + y < OverworldData.DimensionSize && X + x >= 0 && Z + y >= 0)
        {
            if (x == 0)
            {
                Z += y;
            }
            else
            {
                X += x;
            }

            position.position += new Vector3(x, 0, y);
        }
        else
        {
            print("Don't let your ship run aground!");
        }
    }

    public void QuaterTurnRight()
    {
        Quaternion quaterTurn = Quaternion.Euler(Vector3.forward * 90);
        if (Direction == Directions.North)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.East;
        }
        else if (Direction == Directions.South)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.West;
        }
        else if (Direction == Directions.East)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.South;
        }
        else if (Direction == Directions.West)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.North;
        }
    }

    public void QuaterTurnLeft()
    {
        Quaternion quaterTurn = Quaternion.Euler(Vector3.forward * 90);
        if (Direction == Directions.North)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.West;
        }
        else if (Direction == Directions.South)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.East;
        }
        else if (Direction == Directions.East)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.North;
        }
        else if (Direction == Directions.West)
        {
            transform.rotation = quaterTurn;
            Direction = Directions.South;
        }
    }

    public bool[] GetDamagedParts()
    {
        return partDamaged;
    }

    public void InitiateShip(int shipNr)
    {
        ShipName = "ship" + PartsCount.ToString();
        Dimension = 0;
        position = GetComponent<Transform>();
        X = shipNr;
        Direction = Directions.North;
        PartsCount = shipNr + 2;
        partDamaged = new bool[PartsCount];

        for (int i = 0; i < shipNr; i++)
        {
            partDamaged[i] = false;
        }
    }
}
