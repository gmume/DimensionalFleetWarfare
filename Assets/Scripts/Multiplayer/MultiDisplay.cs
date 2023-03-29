using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    private Camera camera1A;
    private Camera camera1B;
    private Camera camera2A;
    private Camera camera2B;

    public void Start()
    {
        Debug.Log("enterd MultiDisplay Start()");
        camera1A = GameObject.Find("Camera1A").GetComponent<Camera>();
        camera1B = GameObject.Find("Camera1B").GetComponent<Camera>();
        camera2A = GameObject.Find("Camera2A").GetComponent<Camera>();
        camera2B = GameObject.Find("Camera2B").GetComponent<Camera>();

        // GUI is rendered with last camera.
        // As we want it to end up in the main screen, make sure main camera is the last one drawn.
        SetDepth(camera1A, camera2A);
        Debug.Log("camera.enabled? " + camera1A.enabled + ", " + camera2A.enabled);

        camera1A.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);

        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        Display.displays[1].SetRenderingResolution(256, 256);
        camera2A.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
        camera2A.enabled = Display.displays.Length > 1;

        camera1B.enabled = false;
        camera2B.enabled = false;
    }

    //void Update() { }

    public void CamerasOnDisplays(string cam1NrLetter, string cam2NrLetter)
    {
        CameraOnDisplay(cam1NrLetter);
        CameraOnDisplay(cam2NrLetter);
    }

    public void CameraOnDisplay(string camNrLetter)
    {
        switch (camNrLetter)
        {
            case "1A":
                camera1A.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
                break;
            case "1B":
                camera1B.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
                break;
            case "2A":
                camera2A.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
                break;
            case "2B":
                camera2B.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
                break;
            default: Debug.Log("Camera could not be set!");
                break;
        }
    }

    private void SetDepth(Camera camera1, Camera camera2)
    {
        camera1.depth = 1;
        camera2.depth = 0;
    }

    //private void InitPlayPhace()
    //{
    //    //resolve
    //    //init/update
    //}
}