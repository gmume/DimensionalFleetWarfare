using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [Range(1,5)] [SerializeField]
    private int dimensionsCount;
    [Range(5, 19)] [SerializeField]
    private float dimensionSize; //Should be uneven!
    [Range(1, 5)] [SerializeField]
    private int fleetSize;

    private Dimensions dimensions1;
    //public Dimensions dimensions2;

    public GameObject dimensionPrefab;
    public GameObject cellPrefab;
    public GameObject shipPrefab;

    private void Awake()
    {
        GameData.DimensionsCount = dimensionsCount;
        GameData.DimensionSize = (int)dimensionSize;
        GameData.DimensionDiagonal = dimensionSize * Mathf.Sqrt(2);
        GameData.FleetSize = fleetSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions1.InitDimensions(dimensionPrefab, cellPrefab, shipPrefab);
        GetComponent<PlayerMoves>().InitPlayerMoves(dimensions1);
    }

    void OnValidate()
    {
        dimensionSize = 1 + (((int)(dimensionSize + 1.0f) - 1) & 0xFFFFFFFE);
    }

    public Dimensions GetDimensions()
    {
        return dimensions1;
    }
}
