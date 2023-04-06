using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class FleetMenuScript : MonoBehaviour
{
    private GameObject fleetMenu;

    public EventSystem eventSystem;
    public GameObject firstSelectedButton;
    public GameObject selectedElement;
    private readonly ArrayList buttons = new();

    private void Start()
    {
        if (name == "FleetMenu1")
        {
            fleetMenu = GameObject.Find("FleetMenu1");
        }
        else
        {
            fleetMenu = GameObject.Find("FleetMenu2");
        }

        CreateShipButtons();
    }

    private void Update()
    {
        selectedElement = eventSystem.currentSelectedGameObject;
    }

    public void FleetMenuOpenClose(CallbackContext ctx)
    {
        if (ctx.performed == true)
        {
            if (!fleetMenu.activeInHierarchy)
            {
                fleetMenu.SetActive(true);
                eventSystem.SetSelectedGameObject(null);
            }
            else
            {
                fleetMenu.SetActive(false);
                SetFirstSelecetedButton();
            }
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
            buttonNavigation.mode = Navigation.Mode.Horizontal;
            //Debug.Log("buttonNavigation: " + buttonNavigation + ", mode: " + buttonNavigation.mode);

            AddOnClickListener(buttonObj, button, i, player);

            if (i == 0)
            {
                firstSelectedButton = buttonObj;
                SetFirstSelecetedButton();
            }
            buttons.Add(button);
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
        shipButton.ShipNr = shipNr;
        Fleet fleet = player.GetComponent<PlayerScript>().GetFleet();
        button.onClick.AddListener(() => fleet.ActivateShip(shipButton.ShipNr, player));
    }

    public void SetFirstSelecetedButton()
    {
        eventSystem.SetSelectedGameObject(firstSelectedButton);
    }
}
