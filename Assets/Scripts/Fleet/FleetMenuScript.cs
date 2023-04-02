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
    public GameObject selectedElement;

    private void Start()
    {
        if (this.name == "FleetMenu1")
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
                //eventSystem.SetSelectedGameObject(ship1Button);
            }
            else
            {
                fleetMenu.SetActive(false);
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
            button.transform.SetParent(this.transform, false);

            if (this.name == "FleetMenu1")
            {
                buttonObj.name = "Ship1." + (i + 1).ToString();
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Ship" + (i + 1).ToString();
                button.colors = ChangeButtonColors(button.colors);
                buttonObj.layer = 11;

                if(player == null || player.name != "Player1")
                {
                    Debug.Log("entred if Player1");
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
                    Debug.Log("entred if Player2");
                    player = GameObject.Find("Player2");
                }
            }

            button.onClick.AddListener(new UnityAction(player.GetComponent<PlayerScript>().GetFleet().ActivateShip)); // Does not work, yet!!
            Debug.Log("button.onClick.GetPersistentTarget(0): "+button.onClick.GetPersistentEventCount());
            button.navigation = new Navigation() { mode = Navigation.Mode.Horizontal };

            if (i == 0)
            {
                eventSystem.firstSelectedGameObject = buttonObj;
            }
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
}
