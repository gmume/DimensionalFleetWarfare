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

    public void InitDimensions(int countDimensions, int size, int fleetSize)
    {
        dimensionsCount = countDimensions;
        dimensionSize = size;
        CreateDimensions();
        //Cell cell = dimensions1.GetCell(1, 1, 2);
        //Debug.Log("Cell112: " + cell);
        //Debug.Log("CellX: " + cell.GetX());
        //Debug.Log("CellY: " + cell.GetY());
        InitFleet(fleetSize);
    }

    public void CreateDimensions()
    {
        for (int i = 0; i < dimensionsCount; i++)
        {
            Dimension dimension = ScriptableObject.CreateInstance("Dimension") as Dimension;
            dimension.InitDimension(i, dimensionSize, fleet.GetFleet());
            dimensions.Add(dimension);
        }
        //Debug.Log("dimensions[0]: " + dimensions[0]);
    }

    public void InitFleet(int fleetSize)
    {
        fleet = ScriptableObject.CreateInstance("Fleet") as Fleet;
        fleet.SetFleetSize(fleetSize);
        fleet.CreateFleet();
    }
}
