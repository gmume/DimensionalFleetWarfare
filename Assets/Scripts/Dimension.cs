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
                GameObject cell = Instantiate(cellPrefab, new Vector3(j, dimensionSize * dimensionNr, k), Quaternion.identity);
                cell.transform.parent = this.transform;
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
        foreach(GameObject ship in newShips)
        {
            if(ship.GetComponent<Ship>().GetDimension() == dimensionNr)
            {
                ship.transform.parent = this.transform;
                ships.Add(ship);
            }
        }
    }
}
