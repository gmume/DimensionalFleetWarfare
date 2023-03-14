using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    private int dimensionNr;
    private Cell[][] cells;
    private readonly ArrayList ships;

    public void InitDimension(int nr, int size, ArrayList fleet)
    {
        Debug.Log("entred InitDimension()");
        dimensionNr = nr;
        CreateCells(size);
        AddShips(fleet);
    }

    public void CreateCells(int dimensionSize)
    {
        cells = new Cell[dimensionSize][];

        for (int j = 0; j < dimensionSize; j++)
        {
            cells[j] = new Cell[dimensionSize];

            for (int k = 0; k < dimensionSize; k++)
            {
                Cell cell = ScriptableObject.CreateInstance("Cell") as Cell;
                cell.SetX(j);
                cell.SetY(k);
                cells[j][k] = cell;
                //Debug.Log("cellX: " + cells[j][k].GetX());
                //Debug.Log("cellY: " + cells[j][k].GetY());
            }
        }
    }

    public int GetDimensionNr()
    {
        return dimensionNr;
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x][y];
    }

    public void AddShips(ArrayList newShips)
    {
        foreach(Ship ship in newShips)
        {
            if(ship.getDimension() == dimensionNr)
            {
                ships.Add(ship);
            }
        }
    }
}
