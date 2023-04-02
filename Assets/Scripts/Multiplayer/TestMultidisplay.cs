using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestMultidisplay : MonoBehaviour
{
    public Camera camera1, camera2;
    public Text myText;

    void Start()
    {
        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }

        Debug.Log("Display connected: " + Display.displays.Length);
    }


    //GameObject cameraObj1;
    //GameObject cameraObj2;
    //Camera camera1;
    //Camera camera2;

    //void Start()
    //{
    //    cameraObj1 = GameObject.Find("Camera1");
    //    cameraObj2 = GameObject.Find("Camera2");
    //    //Debug.Log("cameraObj2: " + cameraObj2);

    //    camera1 = cameraObj1.GetComponent<Camera>();
    //    camera2 = cameraObj2.GetComponent<Camera>();
    //    //Debug.Log("camera2.target: " + camera2.targetDisplay);


    //    // GUI is rendered with last camera.
    //    // As we want it to end up in the main screen, make sure main camera is the last one drawn.
    //    camera2.depth = camera1.depth - 1;

    //    camera1.SetTargetBuffers(Display.main.colorBuffer, Display.main.depthBuffer);
    //    camera2.enabled = false;
    //    //Debug.Log("Display.displays.Lengt: "+ Display.displays.Length);
    //    Display.displays[1].Activate();
    //}

    //void Update()
    //{
    //    //Debug.Log("Display.displays.Lengt: " + Display.displays.Length);
    //    if (Display.displays.Length > 1 && !camera2.enabled)
    //    {
    //        //Debug.Log("entred if");
    //        Display.displays[1].SetRenderingResolution(256, 256);
    //        camera2.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
    //    }
    //    camera2.enabled = Display.displays.Length > 1;
    //}
}
