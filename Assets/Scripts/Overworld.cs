using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overworld : MonoBehaviour
{
    [Range(1,5)] [SerializeField]
    private int dimensionsCount;
    [Range(5, 19)] [SerializeField]
    private float dimensionSize; //Should be uneven!
    [Range(1, 5)] [SerializeField]
    private int fleetSize;

    private PlayerScript player1;
    private PlayerScript player2;

    private void Awake()
    {
        OverworldData.DimensionsCount = dimensionsCount;
        OverworldData.DimensionSize = (int)dimensionSize;
        OverworldData.DimensionDiagonal = dimensionSize * Mathf.Sqrt(2);
        OverworldData.FleetSize = fleetSize;
        OverworldData.PlayerTurn = 1;
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
    //    dimensions1.InitDimensions(dimensionPrefab, cellPrefab, shipPrefab);
    //    GetComponent<PlayerScript>().InitPlayerScript(dimensions1);
    //}

    void OnValidate()
    {
        dimensionSize = 1 + (((int)(dimensionSize + 1.0f) - 1) & 0xFFFFFFFE);
    }
}
