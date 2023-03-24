using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    private PlayerScript player;
    private string playerName;

    private void Start()
    {
        player = GetComponent<PlayerScript>();
        playerName = gameObject.name;
    }

    public void OnSubmit()
    {
        //Based on context trigger event?
        //submited ctx: ship selected, cell selected
        Debug.Log("Submited!");
    }

    public void OnCancel()
    {
        //close ship menu
        Debug.Log("Canceled!");
    }

    public void OnChangeFocus()
    {
        //Shift view on own dimensions to view on oponents dimensions
        Debug.Log("Changed focus!");
    }

    public void OnMoveSelection(CallbackContext ctx)
    {
        if(ctx.performed == true)
        {
            if (playerName == "Player1" && OverworldData.PlayerTurn == 1 || playerName == "Player2" && OverworldData.PlayerTurn == 2)
            {
                //Debug.Log("Selection moved!");
                //Change activeted cell
                Vector2 vector = ctx.ReadValue<Vector2>();
                float x = vector.x;
                float y = vector.y;

                //Get right axis
                if (Math.Abs(x) > Math.Abs(y))
                {
                    //negative or positive?
                    if (x > 0)
                    {
                        player.SetNewCell(1, 0);
                    }
                    else
                    {
                        player.SetNewCell(-1, 0);
                    }
                }
                else
                {
                    if (y > 0)
                    {
                        player.SetNewCell(0, 1);
                    }
                    else
                    {
                        player.SetNewCell(0, -1);
                    }
                }
            }
            else
            {
                print("It's not your turn!");
            }
        }
    }

    public void OnFleetMenu()
    {
        //Open fleet menu
        Debug.Log("Fleet menu selected!");
    }

    public void OnShipLeft()
    {
        //Shift to the left ship
        Debug.Log("Ship left selected!");
    }

    public void OnShipRight()
    {
        //Shift to the right ship
        Debug.Log("Ship right selected!");
    }

    public void OnTurnLeft()
    {
        //Turn ship left
        Debug.Log("Turned left!");
    }

    public void OnTurnRight()
    {
        //Turn ship right
        Debug.Log("Turned right!");
    }

    public void OnFire(CallbackContext ctx)
    {
        if (ctx.performed == true)
        {
            if (playerName == "Player1" && OverworldData.PlayerTurn == 1 || playerName == "Player2" && OverworldData.PlayerTurn == 2)
            {
                //Fire on selected cell
                //Debug.Log("Fired!");
                Material cellMaterial = player.playerData.ActiveCell.GetComponent<Renderer>().material;
                cellMaterial.color = Color.red;
                player.playerData.ActiveCell.Hitted = true;

                if (playerName == "Player1")
                {
                    OverworldData.PlayerTurn = 2;
                }
                else
                {
                    OverworldData.PlayerTurn = 1;
                }
            }
            else
            {
                print("It's not your turn!");
            }
        }
    }
}
