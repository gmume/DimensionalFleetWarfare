using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using static UnityEngine.InputSystem.InputAction;

public class InputHandling : MonoBehaviour
{
    private PlayerScript playerScript, opponent;
    private PlayerInput playerInput;
    private InputActionMap gameStartMap;
    private InputActionMap playerMap;
    private InputActionMap FleetMenuMap;

    private void Start()
    {
        playerScript = GetComponent<PlayerScript>();
        playerInput = GetComponent<PlayerInput>();
        gameStartMap = playerInput.actions.FindActionMap("GameStart");
        playerMap = playerInput.actions.FindActionMap("Player");
        FleetMenuMap = playerInput.actions.FindActionMap("FleetMenu");

        if (name == "Player1")
        {
            opponent = GameObject.Find("Player2").GetComponent<PlayerScript>();
        }
        else
        {
            opponent = GameObject.Find("Player1").GetComponent<PlayerScript>();
        }

        playerInput.SwitchCurrentActionMap("FleetMenu");
        SwitchActionMap("FleetMenu");
    }

    //StartGame actionMap
    public void OnReturnToFleetMenu(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            playerScript.playerData.ActiveShip.Deactivate(playerScript);
            playerInput.SwitchCurrentActionMap("FleetMenu");
            SwitchActionMap("FleetMenu");

            if (name == "Player1")
            {
                GameObject.Find("FleetMenu1").GetComponent<FleetMenuScript>().SetFirstSelecetedButton();
            }
            else
            {
                GameObject.Find("FleetMenu2").GetComponent<FleetMenuScript>().SetFirstSelecetedButton();
            }
        }
    }

    public void OnMoveShip(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 vector = ctx.ReadValue<Vector2>();
            float x = vector.x;
            float y = vector.y;

            //Get right axis
            if (Math.Abs(x) > Math.Abs(y))
            {
                if (x > 0)
                {
                    playerScript.playerData.ActiveShip.Move(1, 0);
                }
                else
                {
                    playerScript.playerData.ActiveShip.Move(-1, 0);
                }
            }
            else
            {
                if (y > 0)
                {
                    playerScript.playerData.ActiveShip.Move(0, 1);
                }
                else
                {
                    playerScript.playerData.ActiveShip.Move(0, -1);
                }
            }
        }
    }

    public void OnTurnLeft(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //Turn ship left
            playerScript.playerData.ActiveShip.GetComponent<Transform>().Rotate(0, -90, 0);
        }
    }

    public void OnTurnRight(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //Turn ship right
            playerScript.playerData.ActiveShip.GetComponent<Transform>().Rotate(0, 90, 0);
        }
    }

    public void OnSubmitFleet(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //To do: Popup "Are you sure?"


            if (playerScript.playerData.ActiveShip != null)
            {
                playerScript.playerData.ActiveShip.Deactivate(playerScript);
            }

            if (name == "Player1")
            {
                OverworldData.Player1SubmittedFleet = true;
            }
            else
            {
                OverworldData.Player2SubmittedFleet = true;
            }

            if (!OverworldData.Player1SubmittedFleet || !OverworldData.Player2SubmittedFleet)
            {
                Debug.Log("Please, wait until your opponent is ready.");
                playerInput.DeactivateInput();
                StartCoroutine(WaitForOpponent());
            }

            playerInput.SwitchCurrentActionMap("Player");
            SwitchActionMap("Player");
        }
    }

    private IEnumerator WaitForOpponent()
    {
        Debug.Log("Both submitted fleet: " + (OverworldData.Player1SubmittedFleet && OverworldData.Player2SubmittedFleet));
        yield return new WaitUntil(() => (OverworldData.Player1SubmittedFleet && OverworldData.Player2SubmittedFleet));
        Debug.Log("Your opponent is ready. Let's go!");
        playerInput.ActivateInput();
    }

    //Player actionMap
    public void OnSubmit(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("OnSubmit!");
        }
    }

    public void OnCancel(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //close ship menu
            Debug.Log("OnCancel!");
        }
    }

    public void OnMoveSelection(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (name == "Player1" && OverworldData.PlayerTurn == 1 || name == "Player2" && OverworldData.PlayerTurn == 2)
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

    public void OnFire(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (name == "Player1" && OverworldData.PlayerTurn == 1 || name == "Player2" && OverworldData.PlayerTurn == 2)
            {
                //Fire on selected cell
                //Debug.Log("Fired!");
                Material cellMaterial = playerScript.playerData.ActiveCell.GetComponent<Renderer>().material;

                playerScript.playerData.ActiveCell.Hitted = true;

                if (name == "Player1")
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
                playerScript.ChangeCameraVehicle();
                opponent.ChangeCameraVehicle();
            }
            else
            {
                print("It's not your turn, yet!");
            }
        }
    }

    private IEnumerable<WaitForSecondsRealtime> WaitForEndOfFrame(int sec)
    {
        yield return new WaitForSecondsRealtime(sec);
    }

    //FleetMenu actionMap
    //public void OnSubmit()
    //{

    //}

    //public void OnShipLeft(CallbackContext ctx)
    //{
    //    if (ctx.performed)
    //    {
    //        //Shift to the left ship
    //        Debug.Log("Ship left selected!");
    //    }
    //}

    //public void OnShipRight(CallbackContext ctx)
    //{
    //    if (ctx.performed)
    //    {
    //        //Shift to the right ship
    //        Debug.Log("Ship right selected!");
    //    }
    //}

    public void SwitchActionMap(string actionMapName)
    {
        switch (actionMapName)
        {
            case "GameStart":
                if (!gameStartMap.enabled)
                {
                    gameStartMap.Enable();
                }
                if (playerMap.enabled)
                {
                    playerMap.Disable();
                }
                if (FleetMenuMap.enabled)
                {
                    FleetMenuMap.Disable();
                }
                break;
            case "Player":
                if (gameStartMap.enabled)
                {
                    gameStartMap.Disable();
                }
                if (!playerMap.enabled)
                {
                    playerMap.Enable();
                }
                if (FleetMenuMap.enabled)
                {
                    FleetMenuMap.Disable();
                }
                break;
            case "FleetMenu":
                if (gameStartMap.enabled)
                {
                    gameStartMap.Disable();
                }
                if (playerMap.enabled)
                {
                    playerMap.Disable();
                }
                if (!FleetMenuMap.enabled)
                {
                    FleetMenuMap.Enable();
                }
                break;
            default:
                Debug.Log("No such action map!");
                break;
        }
    }
}
