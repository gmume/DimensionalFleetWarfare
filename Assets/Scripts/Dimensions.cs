using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dimensions")]

public class Dimensions : ScriptableObject
{
    private int dimensionsCount;
    private int dimensionSize; //Should be uneven!
    private readonly ArrayList dimensions = new();

    public Fleet fleet;

    public void InitDimensions(int countDimensions, int size, GameObject prefabDimension, GameObject prefabCell, int fleetSize)
    {
        dimensionsCount = countDimensions;
        dimensionSize = size;
        InitFleet(fleetSize);
        CreateDimensions(prefabDimension, prefabCell);
    }

    public void CreateDimensions(GameObject dimensionPrefab, GameObject cellPrefab)
    {
        for (int dimensionNr = 0; dimensionNr < dimensionsCount; dimensionNr++)
        {
            float halfDimensionSize = dimensionSize / 2;
            GameObject dimension = Instantiate(dimensionPrefab, new Vector3(halfDimensionSize, dimensionSize * dimensionNr, halfDimensionSize), Quaternion.identity);
            dimension.transform.localScale = DimensionSize(dimensionSize);
            dimension.GetComponent<Dimension>().InitDimension(dimensionNr, dimensionSize, cellPrefab, fleet.GetFleet());
            dimensions.Add(dimension);
        }
    }

    public void InitFleet(int fleetSize)
    {
        fleet = ScriptableObject.CreateInstance("Fleet") as Fleet;
        fleet.SetFleetSize(fleetSize);
        fleet.CreateFleet();
    }

    private Vector3 DimensionSize(int dimensionSize)
    {
        float diagonal = dimensionSize * Mathf.Sqrt(2);
        return new Vector3(diagonal, 0.9f, diagonal);
    }
}
