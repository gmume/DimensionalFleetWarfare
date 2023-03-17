using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Range(1,5)] [SerializeField]
    private int dimensionsCount;
    [Range(5, 19)] [SerializeField]
    private int dimensionSize; //Should be uneven!
    [Range(1, 5)] [SerializeField]
    private int fleetSize;

    private Dimensions dimensions1;
    //public Dimensions dimensions2;

    public GameObject dimensionPrefab;
    public GameObject cellPrefab;
    public GameObject shipPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameData.DimensionsCount = dimensionsCount;
        GameData.DimensionSize = dimensionSize;
        GameData.DimensionDiagonal = dimensionSize * Mathf.Sqrt(2);
        GameData.FleetSize = fleetSize;

        dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions1.InitDimensions(dimensionPrefab, cellPrefab, shipPrefab);
    }
}
