using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Fleet")]

public class Fleet : ScriptableObject
{
    private readonly ArrayList fleet = new();

    public void CreateFleet(string playerName, GameObject shipPrefab)
    {
        for (int i = 0; i < OverworldData.FleetSize; i++)
        {
            GameObject ship = Instantiate(shipPrefab, new Vector3(i, 1, 0), Quaternion.identity);
            ship.layer = Layer.SetLayerFleet(playerName);
            ship.GetComponent<Ship>().InitiateShip(i);
            fleet.Add(ship);
        }
    }

    //public void SelectShip()
    //{

    //}

    public void ActivateShip()
    {
        Debug.Log("Ship activeted!");
    }

    public ArrayList GetFleet()
    {
        return fleet;
    }
}
