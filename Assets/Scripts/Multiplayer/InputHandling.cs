using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputHandling : MonoBehaviour
{
    private PlayerScript playerScript;
    private string playerName;
    private PlayerScript opponent;

    private void Start()
    {
        playerScript = GetComponent<PlayerScript>();
        playerName = gameObject.name;
        
        if(playerName == "Player1")
        {
            opponent = GameObject.Find("Player2").GetComponent<PlayerScript>();
        }
        else
        {
            opponent = GameObject.Find("Player1").GetComponent<PlayerScript>();
        }
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
                        playerScript.SetNewCell(1, 0);
                    }
                    else
                    {
                        playerScript.SetNewCell(-1, 0);
                    }
                }
                else
                {
                    if (y > 0)
                    {
                        playerScript.SetNewCell(0, 1);
                    }
                    else
                    {
                        playerScript.SetNewCell(0, -1);
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
                Material cellMaterial = playerScript.playerData.ActiveCell.GetComponent<Renderer>().material;

                playerScript.playerData.ActiveCell.Hitted = true;

                if (playerName == "Player1")
                {
                    cellMaterial.color = Color.red;
                    OverworldData.PlayerTurn = 2;
                }
                else
                {
                    cellMaterial.color = Color.yellow;
                    OverworldData.PlayerTurn = 1;
                }
                WaitForEndOfFrame(3);
                playerScript.ChangeCamera();
                opponent.ChangeCamera();
            }
            else
            {
                print("It's not your turn, yet!");
            }
        }
    }

    private IEnumerable<WaitForSecondsRealtime> WaitForEndOfFrame(int sec)
    {

        yield return new WaitForSecondsRealtime(3);
    }
}
