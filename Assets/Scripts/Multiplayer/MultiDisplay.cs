using UnityEngine;

public class Example : MonoBehaviour
{
    private Camera extCam;
    private Camera cam;

    void Start()
    {
        // GUI is rendered with last camera.
        // As we want it to end up in the main screen, make sure main camera is the last one drawn.
        extCam.depth = cam.depth - 1;

        cam.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
        extCam.enabled = false;
    }

    void Update()
    {
        if (Display.displays.Length > 1 && !extCam.enabled)
        {
            Display.displays[1].SetRenderingResolution(256, 256);
            extCam.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
        }
        extCam.enabled = Display.displays.Length > 1;
    }
}