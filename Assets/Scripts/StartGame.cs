using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Dimensions dimensions1;
    //public Dimensions dimensions2;
    //public Fleet fleet1;

    [Range(1,5)]
    public int dimensionsCount;
    [Range(5, 19)]
    public int dimensionSize;
    [Range(1, 5)]
    public int fleetSize;

    // Start is called before the first frame update
    void Start()
    {
        dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions1.InitDimensions(dimensionsCount, dimensionSize, fleetSize);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
