using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject dimensionPrefab;
    public GameObject cellPrefab;
    public GameObject shipPrefab;

    private GameObject cameraVehicleA;
    private GameObject cameraVehicleB;
    private CameraBehavior cameraBehaviorA;
    private CameraBehavior cameraBehaviorB;
    private GameObject cameraA;
    private GameObject cameraB;
    private Dimensions dimensions;
    private int currentX = 0;
    private int currentY = 0;

    public void Start()
    {
        dimensions = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions.InitDimensions(gameObject.name, dimensionPrefab, cellPrefab, shipPrefab);
        SetNewDimension(0);
        SetNewCell(0, 0);

        if (this.name == "Player1")
        {
            cameraVehicleA = GameObject.Find("CameraVehicle1A");
            cameraVehicleB = GameObject.Find("CameraVehicle1B");
            cameraBehaviorA = cameraVehicleA.GetComponent<CameraBehavior>();
            cameraBehaviorB = cameraVehicleB.GetComponent<CameraBehavior>();
            cameraA = GameObject.Find("Camera1A");
            cameraB = GameObject.Find("Camera1B");

            playerData.ActiveCamera = cameraA;
            playerData.CameraVehicle = cameraVehicleA;
        }
        else
        {
            cameraVehicleA = GameObject.Find("CameraVehicle2A");
            cameraVehicleB = GameObject.Find("CameraVehicle2B");
            cameraBehaviorA = cameraVehicleA.GetComponent<CameraBehavior>();
            cameraBehaviorB = cameraVehicleB.GetComponent<CameraBehavior>();
            cameraA = GameObject.Find("Camera2A");
            cameraB = GameObject.Find("Camera2B");

            playerData.ActiveCamera = cameraB;
            playerData.CameraVehicle = cameraVehicleB;
        }
    }

    public void ChangeCamera()
    {
        if (playerData.ActiveCamera == cameraA)
        {
            cameraBehaviorB.UpdateCamera();
            playerData.CameraVehicle = cameraVehicleB;
            playerData.ActiveCamera = cameraB;
        }
        else
        {
            cameraBehaviorA.UpdateCamera();
            playerData.CameraVehicle = cameraVehicleA;
            playerData.ActiveCamera = cameraA;
        }

        this.GetComponent<PlayerInput>().camera = playerData.ActiveCamera.GetComponent<Camera>();
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
}
