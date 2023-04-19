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
            Debug.Log("entred OnSubmit in FleetMenuScript");
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
        GameObject buttonObj;
        Button button;
        Transform parentsTransform;

        for (int i = 0; i < OverworldData.FleetSize; i++)
        {
            buttonObj = TMP_DefaultControls.CreateButton(new TMP_DefaultControls.Resources());
            button = buttonObj.GetComponent<Button>();

            if (name == "FleetMenu1")
            {
                buttonObj.name = "Ship1." + (i + 1).ToString();
                buttonObj.layer = 11;
                parentsTransform = GameObject.Find("ShipButtons1").GetComponent<Transform>();
            }
            else
            {
                buttonObj.name = "Ship2." + (i + 1).ToString();
                buttonObj.layer = 12;
                parentsTransform = GameObject.Find("ShipButtons2").GetComponent<Transform>();
            }

            //buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Ship" + (i + 1).ToString();

            //button design
            button.colors = ChangeButtonColors(button.colors);

            button.image.type = Image.Type.Simple;
            //Sprite buttonSprite = Resources.Load<Sprite>("HUD_Elemente/ButtonElements/Button") as Sprite;
            //button.image.sprite = buttonSprite;
            //button.image.SetNativeSize();

            button.transition = Selectable.Transition.SpriteSwap;
            Sprite buttonHighlighted = Resources.Load<Sprite>("HUD_Elemente/ButtonElements/Selection") as Sprite;

            SpriteState spriteState = new();
            spriteState.highlightedSprite = buttonHighlighted;
            button.spriteState = spriteState;

            button.transform.SetParent(parentsTransform, false);
            Navigation buttonNavigation = button.navigation;
            buttonNavigation.mode = Navigation.Mode.None;
            buttonObj.AddComponent<ShipButton>();
            buttonObj.GetComponent<ShipButton>().ShipButtonNr = i;

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
        Color subColor = new(0f, 0.5f, 0.5f);

        newButtonColors = buttonColors;
        newButtonColors.selectedColor = Color.cyan;
        newButtonColors.pressedColor = Color.cyan - subColor;
        newButtonColors.disabledColor = Color.gray - subColor;
        return newButtonColors;
    }

    public void SetFirstSelecetedButton()
    {
        eventSystem.firstSelectedGameObject = firstSelectedButton;
    }
}
