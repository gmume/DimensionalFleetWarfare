using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dimensions")]

public class Dimensions : ScriptableObject
{
    private readonly ArrayList dimensions = new();

    public Fleet fleet;

    public void InitDimensions(string playerName, GameObject prefabDimension, GameObject prefabCell, GameObject prefabShip)
    {
        InitFleet(playerName, prefabShip);
        CreateDimensions(playerName, prefabDimension, prefabCell);
    }

    public void CreateDimensions(string playerName, GameObject dimensionPrefab, GameObject cellPrefab)
    {
        for (int dimensionNr = 0; dimensionNr < OverworldData.DimensionsCount; dimensionNr++)
        {
            float halfDimensionSize = OverworldData.DimensionSize / 2;
            GameObject dimension = Instantiate(dimensionPrefab, new Vector3(halfDimensionSize, OverworldData.DimensionSize * dimensionNr, halfDimensionSize), Quaternion.identity);
            dimension.layer = Layer.SetLayerPlayer(playerName);
            dimension.transform.localScale = new Vector3(OverworldData.DimensionDiagonal, 0.9f, OverworldData.DimensionDiagonal);
            dimension.GetComponent<Dimension>().InitDimension(playerName, dimensionNr, cellPrefab, fleet.GetFleet());
            dimensions.Add(dimension);
        }
    }

    public void InitFleet(string playerName, GameObject prefabShip)
    {
        fleet = ScriptableObject.CreateInstance("Fleet") as Fleet;
        fleet.CreateFleet(playerName, prefabShip);
    }

    public Dimension GetDimension(int nr)
    {
        GameObject dimension = (GameObject)dimensions[nr];
        return dimension.GetComponent<Dimension>();
    }

    public Fleet GetFleet()
    {
        return fleet;
    }
}