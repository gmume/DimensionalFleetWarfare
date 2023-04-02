using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    private Camera camera1A, camera1B, camera2A, camera2B;

    public void Start()
    {
        Debug.LogError("Force the build console open...");

        camera1A = GameObject.Find("Camera1A").GetComponent<Camera>();
        camera1B = GameObject.Find("Camera1B").GetComponent<Camera>();
        camera2A = GameObject.Find("Camera2A").GetComponent<Camera>();
        camera2B = GameObject.Find("Camera2B").GetComponent<Camera>();

        // GUI is rendered with last camera.
        // As we want it to end up in the main screen, make sure main camera is the last one drawn.

        camera1A.enabled = true;
        camera1B.enabled = false;
        camera2A.enabled = true;
        camera2B.enabled = false;

        camera1A.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);

        //Funktioniert nur im Standallone-Build. Im Editor werden mehrere Displays nicht unterstützt und  Display.displays.Length gibt immer 1 zurück!
        //Debug.LogError("Display.displays.Length: " + Display.displays.Length);

        Display.displays[1].Activate();
        camera2A.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
    }

    public void UpdateCameras()
    {
        camera1A.enabled = !camera1A.enabled;
        camera1B.enabled = !camera1B.enabled;
        camera2A.enabled = !camera2A.enabled;
        camera2B.enabled = !camera2B.enabled;
    }

    //private void InitPlayPhace()
    //{
    //    //resolve
    //    //init/update
    //}
}