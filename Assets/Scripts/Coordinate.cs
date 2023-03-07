using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Coordinate")]

public class Coordinate : MonoBehaviour
{
    private bool activated = false;
    private bool occupied = false;
    private bool hitted = false;

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }

    public bool getActivated()
    {
        return activated;
    }

    public void occupy()
    {
        occupied = true;
    }

    public void unoccupy()
    {
        occupied = false;
    }

    public bool getOccupied()
    {
        return occupied;
    }

    public void hit()
    {
        hitted = true;
    }

    public void unhit()
    {
        hitted = false;
    }

    public bool getHit()
    {
        return hitted;
    }
}
