using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    private int dimensionNr;
    private GameObject[][] cells;
    private readonly ArrayList ships = new();

    public void InitDimension(int nr, int size, GameObject cellPrefab, ArrayList fleet)
    {
        //Debug.Log("entred InitDimension()");
        dimensionNr = nr;
        CreateCells(size, cellPrefab);
        AddShips(fleet);
    }

    public void CreateCells(int dimensionSize, GameObject cellPrefab)
    {
        cells = new GameObject[dimensionSize][];

        for (int j = 0; j < dimensionSize; j++)
        {
            cells[j] = new GameObject[dimensionSize];

            for (int k = 0; k < dimensionSize; k++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(j, 0, k), Quaternion.identity);
                cell.GetComponent<Cell>().InitCell(j, k);
                cells[j][k] = cell;
            }
        }
    }

    public int GetDimensionNr()
    {
        return dimensionNr;
    }

    public GameObject GetCell(int x, int y)
    {
        return cells[x][y];
    }

    public void AddShips(ArrayList newShips)
    {
        foreach(Ship ship in newShips)
        {
            if(ship.GetDimension() == dimensionNr)
            {
                ships.Add(ship);
            }
        }
    }
}
