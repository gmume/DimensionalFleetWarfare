using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Fleet")]

public class Fleet : ScriptableObject
{
    private int fleetSize;
    private readonly ArrayList fleet = new();

    public void SetFleetSize(int size)
    {
        fleetSize = size;
    }

    public void CreateFleet()
    {
        for (int i = 0; i < fleetSize; i++)
        {
            //Ship ship = ScriptableObject.CreateInstance("Ship") as Ship;
            //ship.InitiateShip(i);
            //fleet.Add(ship);
        }
    }

    public ArrayList GetFleet()
    {
        return fleet;
    }
}
