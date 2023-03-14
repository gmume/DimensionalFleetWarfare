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

    public void InitDimensions(int countDimensions, int size, GameObject prefab, int fleetSize)
    {
        dimensionsCount = countDimensions;
        dimensionSize = size;
        InitFleet(fleetSize);
        CreateDimensions(prefab);
    }

    public void CreateDimensions(GameObject prefab)
    {
        for (int i = 0; i < dimensionsCount; i++)
        {
            GameObject dimension = Instantiate(prefab, new Vector3(0, 0, i), Quaternion.identity);
            dimension.GetComponent<Dimension>().InitDimension(i, dimensionSize, fleet.GetFleet());
            dimensions.Add(dimension);
        }
    }

    public void InitFleet(int fleetSize)
    {
        fleet = ScriptableObject.CreateInstance("Fleet") as Fleet;
        fleet.SetFleetSize(fleetSize);
        fleet.CreateFleet();
    }
}
