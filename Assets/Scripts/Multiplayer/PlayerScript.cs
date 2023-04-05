using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerData playerData;
    public string ShipName;
    public GameObject dimensionPrefab, cellPrefab, shipPrefab;

    private GameObject cameraVehicleA, cameraVehicleB;
    private VehicleBehavior vehicleBehaviorA, vehicleBehaviorB;
    private Dimensions dimensions;
    private int currentX = 0, currentY = 0;

    public void Start()
    {
        dimensions = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions.InitDimensions(gameObject.name, dimensionPrefab, cellPrefab, shipPrefab);
        SetNewDimension(0);
        SetNewCell(0, 0);

        if (name == "Player1")
        {
            cameraVehicleA = GameObject.Find("CameraVehicle1A");
            cameraVehicleB = GameObject.Find("CameraVehicle1B");
            vehicleBehaviorA = cameraVehicleA.GetComponent<VehicleBehavior>();
            vehicleBehaviorB = cameraVehicleB.GetComponent<VehicleBehavior>();

            playerData.VehicleBehavior = vehicleBehaviorA;
        }
        else
        {
            cameraVehicleA = GameObject.Find("CameraVehicle2A");
            cameraVehicleB = GameObject.Find("CameraVehicle2B");
            vehicleBehaviorA = cameraVehicleA.GetComponent<VehicleBehavior>();
            vehicleBehaviorB = cameraVehicleB.GetComponent<VehicleBehavior>();

            playerData.VehicleBehavior = vehicleBehaviorB;
        }
    }

    private void Update()
    {
        if(playerData.ActiveShip == null)
        {
            ShipName = "no ship";
        }
        else
        {
            ShipName = playerData.ActiveShip.ShipName;
        }
    }

    public void ChangeCameraVehicle()
    {
        if (playerData.VehicleBehavior == vehicleBehaviorA)
        {
            vehicleBehaviorB.UpdateVehicle();
            playerData.VehicleBehavior = vehicleBehaviorB;
        }
        else
        {
            vehicleBehaviorA.UpdateVehicle();
            playerData.VehicleBehavior = vehicleBehaviorA;
        }
    }

    public void SetNewDimension(int nr)
    {
        playerData.ActiveDimension = dimensions.GetDimension(nr);
    }

    public void SetNewCell(int x, int y)
    {
        if (playerData.ActiveCell != null)
        {
            DeactivateCell();
        }
        currentX += x;
        currentY += y;
        playerData.ActiveCell = dimensions.GetDimension(playerData.ActiveDimension.DimensionNr).GetCell(currentX, currentY).GetComponent<Cell>();
        ActivateCell();
    }

    public void ActivateCell()
    {
        playerData.ActiveCell.gameObject.transform.position += new Vector3(0, 0.2f, 0);
    }

    public void DeactivateCell()
    {
        playerData.ActiveCell.gameObject.transform.position -= new Vector3(0, 0.2f, 0);
    }

    public Dimensions GetDimensions()
    {
        return dimensions;
    }

    public Fleet GetFleet()
    {
        return GetDimensions().GetFleet();
    }
}
