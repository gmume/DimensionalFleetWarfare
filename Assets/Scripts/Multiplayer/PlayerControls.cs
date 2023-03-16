using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // assign the actions asset to this field in the inspector:
    public InputActionAsset input;

    //store the inputActionMaps here
    private InputActionMap player;

    // private fields to store action reference
    private InputAction submitAction;
    private InputAction cancelAction;
    private InputAction changeFocusAction;
    private InputAction dimensionUpAction;
    private InputAction dimensionDownAction;
    private InputAction moveSelectionAction;
    private InputAction moveCameraAction;
    private InputAction fleetMenuAction;
    private InputAction shipLeftAction;
    private InputAction shipRightAction;
    private InputAction turnLeftAction;
    private InputAction turnRightAction;
    private InputAction fireAction;

    public void Awake()
    {
        // find this action map, and keep the reference to it
        player = input.FindActionMap("Player");

        // find this action, and keep the reference to it, for use in Update
        submitAction        = player.FindAction("Submit");
        cancelAction        = player.FindAction("Cancel");
        changeFocusAction   = player.FindAction("ChangeFocus");
        dimensionUpAction   = player.FindAction("DimensionUp");
        dimensionDownAction = player.FindAction("DimensionDown");
        moveSelectionAction = player.FindAction("MoveSelection");
        moveCameraAction    = player.FindAction("MoveCamera");
        fleetMenuAction     = player.FindAction("FleetMenu");
        shipLeftAction      = player.FindAction("ShipLeft");
        shipRightAction     = player.FindAction("ShipRight");
        turnLeftAction      = player.FindAction("TurnLeft");
        turnRightAction     = player.FindAction("TurnRight");
        fireAction          = player.FindAction("Fire");

        // for this action, we add a callback method for when it is performed
        submitAction.performed        += ctx => { OnSubmit(); };
        cancelAction.performed        += ctx => { OnCancel(); };
        changeFocusAction.performed   += ctx => { OnChangeFocus(); };
        dimensionUpAction.performed   += ctx => { OnDimensionUp(); };
        dimensionDownAction.performed += ctx => { OnDimensionDown(); };
        moveSelectionAction.performed += ctx => { OnMoveSelection(); };
        moveCameraAction.performed    += ctx => { OnMoveCamera(); };
        fleetMenuAction.performed     += ctx => { OnFleetMenu(); };
        shipLeftAction.performed      += ctx => { OnShipLeft(); };
        shipRightAction.performed     += ctx => { OnShipRight(); };
        turnLeftAction.performed      += ctx => { OnTurnLeft(); };
        turnRightAction.performed     += ctx => { OnTurnRight(); };
        fireAction.performed          += ctx => { OnFire(); };
    }

    void Update()
    {
        // our update loop polls this action value each frame
        //Vector2 moveVector = moveAction.ReadValue<Vector2>();

        //Objects, that need to be updated come here?
    }

    public void OnEnable()
    {
        input.Enable();
        
        submitAction.Enable();
        cancelAction.Enable();
        changeFocusAction.Enable();
        dimensionUpAction.Enable();
        dimensionDownAction.Enable();
        moveSelectionAction.Enable();
        moveCameraAction.Enable();
        fleetMenuAction.Enable();
        shipLeftAction.Enable();
        shipRightAction.Enable();
        turnLeftAction.Enable();
        turnRightAction.Enable();
        fireAction.Enable();
    }

    public void OnDisable()
    {
        input.Disable();

        submitAction.Disable();
        cancelAction.Disable();
        changeFocusAction.Disable();
        dimensionUpAction.Disable();
        dimensionDownAction.Disable();
        moveSelectionAction.Disable();
        moveCameraAction.Disable();
        fleetMenuAction.Disable();
        shipLeftAction.Disable();
        shipRightAction.Disable();
        turnLeftAction.Disable();
        turnRightAction.Disable();
        fireAction.Disable();
    }

    public void OnSubmit()
    {
        Debug.Log("Submited!");
    }

    public void OnCancel()
    {
        Debug.Log("Canceled!");
    }

    public void OnChangeFocus()
    {
        Debug.Log("Changed focus!");
    }

    public void OnDimensionUp()
    {

        Debug.Log("Dimension up!");
    }

    public void OnDimensionDown()
    {
        Debug.Log("Dimension down!");
    }

    public void OnMoveSelection()
    {
        Debug.Log("Selection moved!");
    }

    public void OnMoveCamera()
    {
        Debug.Log("Camera moved!");
    }

    public void OnFleetMenu()
    {
        Debug.Log("Fleet menu selected!");
    }

    public void OnShipLeft()
    {

        Debug.Log("Ship left selected!");
    }

    public void OnShipRight()
    {
        Debug.Log("Ship right selected!");
    }

    public void OnTurnLeft()
    {
        Debug.Log("Turned left!");
    }

    public void OnTurnRight()
    {
        Debug.Log("Turned right!");
    }

    public void OnFire()
    {
        Debug.Log("Fired!");
    }
}
