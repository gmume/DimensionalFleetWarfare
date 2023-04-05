using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverworldData
{
    public static GamePhaces GamePhace { get; set; }
    public static int DimensionsCount { get; set; }
    public static int DimensionSize { get; set; }
    public static float DimensionDiagonal { get; set; }
    public static int FleetSize { get; set; }
    public static int PlayerTurn { get; set; }
    public static bool Player1SubmittedFleet { get; set; }
    public static bool Player2SubmittedFleet { get; set; }
}
