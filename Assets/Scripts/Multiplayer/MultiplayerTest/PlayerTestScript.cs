using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestScript : MonoBehaviour
{

    public void OnFire()
    {
        if(this.CompareTag("Player1"))
        {
            Material cubeMaterial = GameObject.Find("Sphere").GetComponent<Renderer>().material;
            cubeMaterial.color = Color.red;
        }
        else
        {
            Material cylinderMaterial = GameObject.Find("Cylinder").GetComponent<Renderer>().material;
            cylinderMaterial.color = Color.red;
        }
        
    }
}
