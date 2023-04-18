using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    new Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void UpdateCamera(GamePhaces phace)
    {
        switch (phace)
        {
            case GamePhaces.Armored:
                if(name == "Camera1")
                {
                    camera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Player2", "VisibleShips", "FleetMenu1");
                }
                else
                {
                    camera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Player1", "VisibleShips", "FleetMenu2");
                }
                break;

            case GamePhaces.Attacked:
                if (name == "Camera1")
                {
                    camera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Player1", "Fleet1", "FleetMenu1");
                }
                else
                {
                    camera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Player2", "Fleet2", "FleetMenu2");
                }
                break;

            case GamePhaces.End:
                Debug.Log("Unhandled, yet!");
                break;
            default:
                Debug.Log("No game phace found!");
                break;
        }
    }
}
