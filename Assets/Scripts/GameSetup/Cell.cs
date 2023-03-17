using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x { get; set; }
    public int y { get; set; }
    public bool activated { get; set; }
    public bool occupied { get; set; }
    public bool hitted { get; set; }
}
