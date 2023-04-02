using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/PlayerData")]

public class PlayerData : ScriptableObject
{
    public VehicleBehavior VehicleBehavior { get; set; }
    public Dimension ActiveDimension { get; set; }
    public Cell ActiveCell { get; set; }
}
