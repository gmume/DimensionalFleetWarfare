using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 vector;

    public void Start()
    {
        transform.position += new Vector3(GameData.DimensionSize / 2, GameData.DimensionSize * 2 / 3, -GameData.DimensionSize);
        vector = new Vector3(0, GameData.DimensionSize, 0);
    }

    public void CameraVehicleUp()
    {
        transform.position += vector;
    }

    public void CameraVehicleDown()
    {
        transform.position -= vector;
    }

    public void CameraVehicleLeft()
    {
        Debug.Log("Not implemented, yet!");
    }

    public void CameraVehicleRight()
    {
        Debug.Log("Not implemented, yet!");
    }
}
