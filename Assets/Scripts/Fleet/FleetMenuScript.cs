using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class FleetMenuScript : MonoBehaviour
{
    private GameObject[] shipButtons;
    private ShipButton currentButton;

    public EventSystem eventSystem;
    public GameObject firstSelectedButton;
    public GameObject selectedElement;

    private void Start()
    {
        shipButtons = new GameObject[OverworldData.FleetSize];
        CreateShipButtons();
    }

    //FleetMenu actionMap
    public void OnShipLeft(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //Shift to the left ship
            int shipNr = currentButton.ShipButtonNr;

            if (shipNr > 0)
            {
                eventSystem.SetSelectedGameObject(shipButtons[shipNr - 1]);
                currentButton = eventSystem.currentSelectedGameObject.GetComponent<ShipButton>();
            }
        }
    }

    public void OnShipRight(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //Shift to the right ship
            int shipNr = currentButton.ShipButtonNr;

            if (shipNr < OverworldData.FleetSize)
            {
                eventSystem.SetSelectedGameObject(shipButtons[shipNr + 1]);
                currentButton = eventSystem.currentSelectedGameObject.GetComponent<ShipButton>();
            }
        }
    }

    public void OnSubmit(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameObject player;
            if (name == "FleetMenu1")
            {
                player = GameObject.Find("Player1");
            }
            else
            {
                player = GameObject.Find("Player2");
            }
            Fleet fleet = player.GetComponent<PlayerScript>().GetFleet();
            fleet.ActivateShip(currentButton.ShipButtonNr, player);
        }
    }

    private void CreateShipButtons()
    {
        GameObject player = null;
        for (int i = 0; i < OverworldData.FleetSize; i++)
        {
            GameObject buttonObj = TMP_DefaultControls.CreateButton(new TMP_DefaultControls.Resources());
            Button button = buttonObj.GetComponent<Button>();
            button.transform.SetParent(transform, false);

            if (name == "FleetMenu1")
            {
                buttonObj.name = "Ship1." + (i + 1).ToString();
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Ship" + (i + 1).ToString();
                button.colors = ChangeButtonColors(button.colors);
                buttonObj.layer = 11;

                if(player == null || player.name != "Player1")
                {
                    player = GameObject.Find("Player1");
                }
            }
            else
            {
                buttonObj.name = "Ship2." + (i + 1).ToString();
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Ship" + (i + 1).ToString();
                button.colors = ChangeButtonColors(button.colors);
                buttonObj.layer = 12;

                if (player == null || player.name != "Player2")
                {
                    player = GameObject.Find("Player2");
                }
            }

            Navigation buttonNavigation = button.navigation;
            buttonNavigation.mode = Navigation.Mode.None;
            AddOnClickListener(buttonObj, button, i, player);

            if (i == 0)
            {
                firstSelectedButton = buttonObj;
                SetFirstSelecetedButton();
                currentButton = buttonObj.GetComponent<ShipButton>();
            }

            shipButtons[i] = buttonObj;
        }
    }

    private ColorBlock ChangeButtonColors(ColorBlock buttonColors)
    {
        ColorBlock newButtonColors;
        Color subColor = new(0.5f, 0.5f, 0.5f);

        newButtonColors = buttonColors;
        newButtonColors.selectedColor = Color.green;
        newButtonColors.pressedColor = Color.green - subColor;
        newButtonColors.disabledColor = Color.gray - subColor;
        return newButtonColors;
    }

    private void AddOnClickListener(GameObject buttonObj,Button button, int shipNr, GameObject player)
    {
        buttonObj.AddComponent<ShipButton>();
        ShipButton shipButton = buttonObj.GetComponent<ShipButton>();
        shipButton.ShipButtonNr = shipNr;
        //Fleet fleet = player.GetComponent<PlayerScript>().GetFleet();
        //button.onClick.AddListener(() => fleet.ActivateShip(shipButton.ShipButtonNr, player));
    }

    public void SetFirstSelecetedButton()
    {
        eventSystem.firstSelectedGameObject = firstSelectedButton;
    }
}
