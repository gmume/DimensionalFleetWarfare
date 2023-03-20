using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    // assign the actions asset to this field in the inspector:
    public InputActionAsset input;

    //store the inputActionMaps here
    private InputActionMap player;

    // private fields to store action reference
    [SerializeField] private InputAction submitAction;
    [SerializeField] private InputAction cancelAction;
    [SerializeField] private InputAction changeFocusAction;
    [SerializeField] private InputAction dimensionUpAction;
    [SerializeField] private InputAction dimensionDownAction;
    [SerializeField] private InputAction moveSelectionAction;
    [SerializeField] private InputAction moveCameraAction;
    [SerializeField] private InputAction fleetMenuAction;
    [SerializeField] private InputAction shipLeftAction;
    [SerializeField] private InputAction shipRightAction;
    [SerializeField] private InputAction turnLeftAction;
    [SerializeField] private InputAction turnRightAction;
    [SerializeField] private InputAction fireAction;

    private GameObject cameraVehicle;
    private PlayerMoves playerMoves;

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
        moveSelectionAction.performed += ctx => { OnMoveSelection(ctx); };
        //moveSelectionAction.performed += ctx => Debug.Log(ctx.ReadValue<Vector2>());
        moveCameraAction.performed    += ctx => { OnMoveCamera(); };
        fleetMenuAction.performed     += ctx => { OnFleetMenu(); };
        shipLeftAction.performed      += ctx => { OnShipLeft(); };
        shipRightAction.performed     += ctx => { OnShipRight(); };
        turnLeftAction.performed      += ctx => { OnTurnLeft(); };
        turnRightAction.performed     += ctx => { OnTurnRight(); };
        fireAction.performed          += ctx => { OnFire(); };
    }

    private void Start()
    {
        cameraVehicle = GameObject.Find("CameraVehicle");
        playerMoves = GameObject.Find("StartGame").GetComponent<PlayerMoves>();
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
        
        //submitAction.Enable();
        //cancelAction.Enable();
        //changeFocusAction.Enable();
        //dimensionUpAction.Enable();
        //dimensionDownAction.Enable();
        //moveSelectionAction.Enable();
        //moveCameraAction.Enable();
        //fleetMenuAction.Enable();
        //shipLeftAction.Enable();
        //shipRightAction.Enable();
        //turnLeftAction.Enable();
        //turnRightAction.Enable();
        //fireAction.Enable();
    }

    public void OnDisable()
    {
        input.Disable();

        //submitAction.Disable();
        //cancelAction.Disable();
        //changeFocusAction.Disable();
        //dimensionUpAction.Disable();
        //dimensionDownAction.Disable();
        //moveSelectionAction.Disable();
        //moveCameraAction.Disable();
        //fleetMenuAction.Disable();
        //shipLeftAction.Disable();
        //shipRightAction.Disable();
        //turnLeftAction.Disable();
        //turnRightAction.Disable();
        //fireAction.Disable();
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

    public void OnDimensionUp()
    {
        //Shift view to upper dimension
        cameraVehicle.GetComponent<CameraBehavior>().CameraVehicleUp();
    }

    public void OnDimensionDown()
    {
        //Shift view to lower dimension
        cameraVehicle.GetComponent<CameraBehavior>().CameraVehicleDown();
    }

    public void OnMoveSelection(CallbackContext ctx)
    {
        //Change activeted cell
        Vector2 vector = (Vector2)ctx.ReadValueAsObject();
        Debug.Log("vector: " + vector);
        float x = vector.x;
        float y = vector.y;

        //Get right axis
        if (Math.Abs(x) > Math.Abs(y))
        {
            //negative or positive?
            if(x > 0)
            {
                playerMoves.SetNewCell(1, 0);
            }
            else
            {
                playerMoves.SetNewCell(-1, 0);
            }
        }
        else
        {
            if (y > 0)
            {
                playerMoves.SetNewCell(0, 1);
            }
            else
            {
                playerMoves.SetNewCell(0, -1);
            }
        }
    }

    public void OnMoveCamera()
    {
        //Move camera horizontaly around dimension
        Debug.Log("Not supported, yet!");
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

    public void OnFire()
    {
        //Fire on selected cell
        Debug.Log("Fired!");
        Material cellMaterial = GameData.activeCell.GetComponent<Renderer>().material;
        cellMaterial.color = Color.red;
    }
}
