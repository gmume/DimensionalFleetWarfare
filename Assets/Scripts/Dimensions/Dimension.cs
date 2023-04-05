using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    public int DimensionNr { get; private set; }
    private GameObject[][] cells;
    private readonly ArrayList ships = new();

    public void InitDimension(string playerName, int nr, GameObject cellPrefab, ArrayList fleet)
    {
        DimensionNr = nr;
        CreateCells(playerName, cellPrefab);
        AddShips(fleet);
    }

    public void CreateCells(string playerName, GameObject cellPrefab)
    {
        cells = new GameObject[OverworldData.DimensionSize][];

        for (int j = 0; j < OverworldData.DimensionSize; j++)
        {
            cells[j] = new GameObject[OverworldData.DimensionSize];

            for (int k = 0; k < OverworldData.DimensionSize; k++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(j, OverworldData.DimensionSize * DimensionNr, k), Quaternion.identity);
                cell.layer = Layer.SetLayerPlayer(playerName);
                cell.transform.parent = transform;
                cell.GetComponent<Cell>().X = j;
                cell.GetComponent<Cell>().Y = k;
                cell.GetComponent<Cell>().Activated = false;
                cell.GetComponent<Cell>().Occupied = false;
                cell.GetComponent<Cell>().Hitted = false;
                cells[j][k] = cell;
            }
        }
    }

    public GameObject GetCell(int x, int y)
    {
        return cells[x][y];
    }

    public void AddShips(ArrayList newShips)
    {
        foreach(GameObject ship in newShips)
        {
            if(ship.GetComponent<Ship>().Dimension == DimensionNr)
            {
                ship.transform.parent = transform;
                ships.Add(ship);
            }
        }
    }
}
