using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public bool isHit = false;

    public void isHitted()
    {
        isHit = true;
        Debug.Log("Sphere is hittet: " + isHit);
    }
}
