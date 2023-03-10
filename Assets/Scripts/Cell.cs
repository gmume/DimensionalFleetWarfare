using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Cell")]

public class Cell : ScriptableObject
{
    private int x;
    private int y;
    private bool activated = false;
    private bool occupied = false;
    private bool hitted = false;

    public void SetX(int xCoord)
    {
        x = xCoord;
    }

    public int GetX()
    {
        return x;
    }

    public void SetY(int yCoord)
    {
        y = yCoord;
    }

    public int GetY()
    {
        return y;
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }

    public bool GetActivated()
    {
        return activated;
    }

    public void Occupy()
    {
        occupied = true;
    }

    public void Unoccupy()
    {
        occupied = false;
    }

    public bool GetOccupied()
    {
        return occupied;
    }

    public void Hit()
    {
        hitted = true;
    }

    public void Unhit()
    {
        hitted = false;
    }

    public bool GetHit()
    {
        return hitted;
    }
}
