using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 vector;
    private PlayerScript player;

    public void Start()
    {
        transform.position += new Vector3(OverworldData.DimensionSize / 2, OverworldData.DimensionSize * 2 / 3, -OverworldData.DimensionSize);
        vector = new Vector3(0, OverworldData.DimensionSize, 0);

        if (gameObject.name == "CameraVehicle1")
        {
            player = GameObject.Find("Player1").GetComponent<PlayerScript>();
        }
        else
        {
            player = GameObject.Find("Player1").GetComponent<PlayerScript>();
        }
    }

    public void CameraVehicleUp(CallbackContext ctx)
    {
        if (OverworldData.DimensionsCount - 1 > player.playerData.ActiveDimension.DimensionNr && ctx.performed == true)
        {
            player.SetNewDimension(player.playerData.ActiveDimension.DimensionNr + 1);
            transform.position += vector;
        }
    }

    public void CameraVehicleDown(CallbackContext ctx)
    {
        if (player.playerData.ActiveDimension.DimensionNr > 0 && ctx.performed == true)
        {
            player.SetNewDimension(player.playerData.ActiveDimension.DimensionNr - 1);
            transform.position -= vector;
        }
    }
}
