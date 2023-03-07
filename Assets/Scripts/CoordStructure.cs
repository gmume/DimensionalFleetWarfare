using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dimensions")]

public class CoordStructure : MonoBehaviour
{
    public int dimensionsNr = 1;
    public int dimensionSize = 10;

    public List<int[][]> CreateDimensions()
    {
        List<int[][]> dimensions = new();

        for (int i = 0; i < dimensionsNr; i++)
        {
            dimensions.Add(new int[dimensionSize-1][]);
        }

        for (int j = 0; j < dimensionSize - 1; j++)
        {
            for (int k = 0; k < dimensionSize - 1; k++)
            {
                dimensions[j][k] = new int[dimensionSize - 1];
            }
        }
        Debug.Log("dimentsions: " + dimensions);
        return dimensions;
    }
}
