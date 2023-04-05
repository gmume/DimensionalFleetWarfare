using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void ActivateShip(int shipNr, GameObject player)
    {
        GameObject shipObj = (GameObject)fleet[shipNr];
        shipObj.GetComponent<Ship>().Activate(player.GetComponent<PlayerScript>());
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("GameStart");
        player.GetComponent<InputHandling>().SwitchActionMap("GameStart");
    }

    public ArrayList GetFleet()
    {
        return fleet;
    }
}
