using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private Dimensions dimensions1;
    //public Dimensions dimensions2;

    [Range(1,5)]
    public int dimensionsCount;
    [Range(5, 19)]
    public int dimensionSize;
    [Range(1, 5)]
    public int fleetSize;

    public GameObject dimensionPrefab;
    public GameObject cellPrefab;
    public GameObject shipPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions1.InitDimensions(dimensionsCount, dimensionSize, dimensionPrefab, cellPrefab, shipPrefab, fleetSize);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
