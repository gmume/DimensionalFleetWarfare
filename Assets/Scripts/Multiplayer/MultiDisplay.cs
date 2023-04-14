using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    private Camera camera1A, camera1B, camera2A, camera2B;
    private Camera[] cameras;

    public void Start()
    {
        //Debug.LogError("Force the build console open...");

        camera1A = GameObject.Find("Camera1A").GetComponent<Camera>();
        camera1B = GameObject.Find("Camera1B").GetComponent<Camera>();
        camera2A = GameObject.Find("Camera2A").GetComponent<Camera>();
        camera2B = GameObject.Find("Camera2B").GetComponent<Camera>();

        //GUI is rendered with last camera.
        //Make sure main camera is the last one drawn.
        camera1A.enabled = true;
        camera1B.enabled = false;
        camera2A.enabled = true;
        camera2B.enabled = false;

        camera1A.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
        Display.displays[1].Activate();
        camera2A.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);

        cameras = new Camera[4] { camera1A, camera1B, camera2A, camera2B };
    }

    public void UpdateCameras()
    {
        if (OverworldData.GamePhace == GamePhaces.Start)
        {
            SwitchCamera(camera2B);
            OverworldData.GamePhace = GamePhaces.Play;
        }

        if(OverworldData.GamePhace == GamePhaces.Play)
        {
            Debug.Log("entred GamePhaces.Play");
            foreach (Camera camera in cameras)
            {
                if (!camera.enabled)
                {
                    SwitchCamera(camera);
                }
            }
        }
        
        if(OverworldData.GamePhace == GamePhaces.End)
        {
            Debug.Log("Not handled, yet!");
        }
    }

    private void SwitchCamera(Camera camera)
    {
        Debug.Log("entred SwitchCamera, camera"+camera.name);
        if (camera.name.Contains("1"))
        {
            camera1A.enabled = !camera1A.enabled;
            camera1B.enabled = !camera1B.enabled;

            camera.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
        }
        else
        {
            camera2A.enabled = !camera2A.enabled;
            camera2B.enabled = !camera2B.enabled;

            camera.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
        }

        foreach (Camera cam in cameras)
        {
            Debug.Log(cam.name + ": " + cam.enabled);
        }
    }
}