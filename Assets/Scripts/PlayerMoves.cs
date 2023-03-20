using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private Dimensions dimensions;
    private int currentX = 0;
    private int currentY = 0;

    public void InitPlayerMoves(Dimensions newDimensions)
    {
        dimensions = newDimensions;
        SetNewCell(0, 0);
    }

    public void MoveSelection()
    {
        
    }

    public void SetNewDimension(int nr)
    {
        GameData.activeDimension = dimensions.GetDimension(nr);
    }

    public void SetNewCell(int x, int y)
    {
        DeactivateCell();
        currentX = currentX + x;
        currentY = currentY + y;
        GameData.activeCell = dimensions.GetDimension(GameData.activeDimension.DimensionNr).GetCell(currentX, currentY).GetComponent<Cell>();
        ActivateCell();
    }

    public void ActivateCell()
    {
        GameData.activeCell.gameObject.transform.position += new Vector3(0, 0.2f, 0);
    }

    public void DeactivateCell()
    {
        GameData.activeCell.gameObject.transform.position -= new Vector3(0, 0.2f, 0);
    }
}
