using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    public int DimensionNr { get; private set; }
    private GameObject[][] cells;
    private readonly ArrayList ships = new();

    public void InitDimension(PlayerScript playerScript, int nr, GameObject cellPrefab, ArrayList fleet)
    {
        DimensionNr = nr;
        CreateCells(playerScript, cellPrefab);

        if(DimensionNr == 0)
        {
            playerScript.playerData.ActiveDimension = this.GetComponent<Dimension>();
            AddShips(fleet);
            for (int i = 0; i < fleet.Count; i++)
            {
                GameObject shipObj = (GameObject)fleet[i];
                Ship ship = shipObj.GetComponent<Ship>();
                ship.Dimension = this.GetComponent<Dimension>();
                ship.OccupyCell();
            }
        }
    }

    public void CreateCells(PlayerScript playerScript, GameObject cellPrefab)
    {
        cells = new GameObject[OverworldData.DimensionSize][];

        for (int j = 0; j < OverworldData.DimensionSize; j++)
        {
            cells[j] = new GameObject[OverworldData.DimensionSize];

            for (int k = 0; k < OverworldData.DimensionSize; k++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(j, OverworldData.DimensionSize * DimensionNr * 2, k), Quaternion.identity);
                cell.layer = Layer.SetLayerPlayer(playerScript);
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
            if (ship.GetComponent<Ship>().Dimension == this)
            {
                ship.transform.parent = transform;
                ships.Add(ship);
            }
        }
    }
}
