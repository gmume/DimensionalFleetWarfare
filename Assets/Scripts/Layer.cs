using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layer
{
   public static int SetLayer(string player)
    {
        if(player == "Player1")
        {
            return 6;
        }
        else
        {
            return 7;
        }
    }
}