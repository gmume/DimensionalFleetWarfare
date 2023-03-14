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
        for (int i = 0; i < dimensionsCount; i++)
        {
            Debug.Log("wurzel 2: " + Mathf.Sqrt(2f));
            GameObject dimension = Instantiate(dimensionPrefab, new Vector3(0, i, 0), Quaternion.identity);
            dimension.transform.localScale = DimensionSize(dimensionSize);
            dimension.GetComponent<Dimension>().InitDimension(i, dimensionSize, cellPrefab, fleet.GetFleet());
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
        //new Vector3(dimensionSize+dimensionSize/4, 0.5f, dimensionSize + dimensionSize / 4);
        Vector3 vector = new(PerimeterRadius(dimensionSize), 0.5f, PerimeterRadius(dimensionSize));
        //Vector3 vector = new(dimensionSize * Mathf.Sqrt(2f), 0.5f, dimensionSize * Mathf.Sqrt(2f));
        return vector;
    }

    private float PerimeterRadius(int dimensionSize)
    {
        return dimensionSize / Mathf.Sqrt(2f);
    }
}
