using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 vector;

    public void Start()
    {
        transform.position += new Vector3(OverworldData.DimensionSize / 2, OverworldData.DimensionSize * 2 / 3, -OverworldData.DimensionSize);
        vector = new Vector3(0, OverworldData.DimensionSize, 0);
    }

    public void CameraVehicleUp()
    {
        transform.position += vector;
    }

    public void CameraVehicleDown()
    {
        transform.position -= vector;
    }
}
