using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int DimensionsCount { get; set; }
    public static int DimensionSize { get; set; }
    public static float DimensionDiagonal { get; set; }
    public static int FleetSize { get; set; }

    public static Dimension activeDimension { get; set; }
    public static Cell activeCell { get; set; }
}
