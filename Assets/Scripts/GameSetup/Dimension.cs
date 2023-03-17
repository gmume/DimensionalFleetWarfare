using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    public int DimensionNr { get; private set; }
    private GameObject[][] cells;
    private readonly ArrayList ships = new();

    public void InitDimension(int nr, GameObject cellPrefab, ArrayList fleet)
    {
        DimensionNr = nr;
        CreateCells(cellPrefab);
        AddShips(fleet);
    }

    public void CreateCells(GameObject cellPrefab)
    {
        cells = new GameObject[GameData.DimensionSize][];

        for (int j = 0; j < GameData.DimensionSize; j++)
        {
            cells[j] = new GameObject[GameData.DimensionSize];

            for (int k = 0; k < GameData.DimensionSize; k++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(j, GameData.DimensionSize * DimensionNr, k), Quaternion.identity);
                cell.transform.parent = this.transform;
                cell.GetComponent<Cell>().x = j;
                cell.GetComponent<Cell>().y = k;
                cell.GetComponent<Cell>().activated = false;
                cell.GetComponent<Cell>().occupied = false;
                cell.GetComponent<Cell>().hitted = false;
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
                ship.transform.parent = this.transform;
                ships.Add(ship);
            }
        }
    }
}
