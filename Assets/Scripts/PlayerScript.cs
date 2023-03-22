using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject dimensionPrefab;
    public GameObject cellPrefab;
    public GameObject shipPrefab;

    private Dimensions dimensions;
    private int currentX = 0;
    private int currentY = 0;

    public void Start()
    {
        dimensions = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions.InitDimensions(dimensionPrefab, cellPrefab, shipPrefab);
        SetNewDimension(0);
        SetNewCell(0, 0);
    }

    public void SetNewDimension(int nr)
    {
        playerData.ActiveDimension = dimensions.GetDimension(nr);
    }

    public void SetNewCell(int x, int y)
    {
        if (playerData.ActiveCell != null)
        {
            DeactivateCell();
        } 
            currentX += x;
            currentY += y;
            playerData.ActiveCell = dimensions.GetDimension(playerData.ActiveDimension.DimensionNr).GetCell(currentX, currentY).GetComponent<Cell>();
            ActivateCell(); 
    }

    public void ActivateCell()
    {
            playerData.ActiveCell.gameObject.transform.position += new Vector3(0, 0.2f, 0);        
    }

    public void DeactivateCell()
    {
        playerData.ActiveCell.gameObject.transform.position -= new Vector3(0, 0.2f, 0);
    }
}
