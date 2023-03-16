using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/GameSetup/Fleet")]

public class Fleet : ScriptableObject
{
    private int fleetSize;
    private readonly ArrayList fleet = new();

    public void SetFleetSize(int size)
    {
        fleetSize = size;
    }

    public void CreateFleet(GameObject shipPrefab)
    {
        for (int i = 0; i < fleetSize; i++)
        {
            GameObject ship = Instantiate(shipPrefab, new Vector3(i, 1, 0), Quaternion.identity);
            ship.GetComponent<Ship>().InitiateShip(i);
            fleet.Add(ship);
        }
    }

    public ArrayList GetFleet()
    {
        return fleet;
    }
}
