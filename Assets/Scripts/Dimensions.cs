using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dimensions")]

public class Dimensions : ScriptableObject
{
    public int dimensionsNr = 1;
    public int dimensionSize = 9; //Should be uneven!
    public ArrayList dimensions = new();
    public Cell cell;

    public ArrayList CreateDimensions()
    {
        for (int i = 0; i < dimensionsNr; i++)
        {
            Cell[][] cells = new Cell[dimensionSize][];

            for (int j = 0; j < dimensionSize; j++)
            {
                cells[j] = new Cell[dimensionSize];

                for (int k = 0; k < dimensionSize; k++)
                {
                    cell = ScriptableObject.CreateInstance("Cell") as Cell;
                    cell.SetX(j);
                    cell.SetY(k);
                    cells[j][k] = cell;
                    //Debug.Log("cellX: " + cells[j][k].GetX());
                    //Debug.Log("cellY: " + cells[j][k].GetY());
                }
            }

            dimensions.Add(cells);
        }
        //Debug.Log("dimensions[0]: " + dimensions[0]);
        return dimensions;
    }

    public Cell GetCell(int dimension, int x, int y)
    {
        Cell[][] cells = (Cell[][]) dimensions[dimension];
        //Debug.Log("cellXY: " + cells[x][y]);
        return cells[x][y];
    }
}
