using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class VehicleBehavior : MonoBehaviour
{
    public int CurrentDimension { get; private set; }
    private Vector3 vector;
    private GameObject player;
    private PlayerScript playerScript;
    private PlayerData playerData;

    public void Start()
    {
        transform.position += new Vector3(OverworldData.DimensionSize / 2, OverworldData.DimensionSize * 2 / 3, -OverworldData.DimensionSize);
        vector = new Vector3(0, OverworldData.DimensionSize, 0);
        CurrentDimension = 0;

        if (gameObject.name == "CameraVehicle1A")
        {
            player = GameObject.Find("Player1");
        }
        else
        {
            player = GameObject.Find("Player2");
        }
        playerScript = player.GetComponent<PlayerScript>();
        playerData = playerScript.playerData;
    }

    public void CameraVehicleUp(CallbackContext ctx)
    {
        if (OverworldData.DimensionsCount - 1 > playerData.ActiveDimension.DimensionNr && ctx.performed == true)
        {
            CurrentDimension += 1;
            playerScript.SetNewDimension(playerData.ActiveDimension.DimensionNr + 1);
            transform.position += vector;
        }
    }

    public void CameraVehicleDown(CallbackContext ctx)
    {
        if (playerData.ActiveDimension.DimensionNr > 0 && ctx.performed == true)
        {
            CurrentDimension -= 1;
            playerScript.SetNewDimension(playerData.ActiveDimension.DimensionNr - 1);
            transform.position -= vector;
        }
    }
}
