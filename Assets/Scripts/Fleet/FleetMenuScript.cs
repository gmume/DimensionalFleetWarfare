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
    private string x = "--";
    private string y = "--";
    private string dimensionNr = "01";
    private TextMeshProUGUI xCoord;
    private TextMeshProUGUI yCoord;
    private TextMeshProUGUI dimension;
    private GameObject playerObj;
    private PlayerScript playerScript;
    private GameObject[] dimensions;
    private int currenDimension;

    public EventSystem eventSystem;
    public GameObject firstSelectedButton;
    public GameObject selectedElement;

    private void Start()
    {
        shipButtons = new GameObject[OverworldData.FleetSize];
        CreateShipButtons();

        if(name == "FleetMenu1")
        {
            xCoord = GameObject.Find("X-Koordinate1").GetComponent<TextMeshProUGUI>();
            yCoord = GameObject.Find("Y-Koordinate1").GetComponent<TextMeshProUGUI>();
            dimension = GameObject.Find("Dimension1").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            xCoord = GameObject.Find("X-Koordinate2").GetComponent<TextMeshProUGUI>();
            yCoord = GameObject.Find("Y-Koordinate2").GetComponent<TextMeshProUGUI>();
            dimension = GameObject.Find("Dimension2").GetComponent<TextMeshProUGUI>();
        }

        if(name == "FleetMenu1")
        {
            playerObj = GameObject.Find("Player1");
            playerScript = playerObj.GetComponent<PlayerScript>();
        }
        else
        {
            playerObj = GameObject.Find("Player2");
            playerScript = playerObj.GetComponent<PlayerScript>();
        }

        GameObject dimensionsHeader;
        if (name == "FleetMenu1")
        {
            dimensionsHeader = GameObject.Find("DimensionsHeader2");
        }
        else
        {
           dimensionsHeader = GameObject.Find("DimensionsHeader2");
        }

        dimensions = new GameObject[OverworldData.DimensionsCount];
        Debug.Log("dimensionsHeader: " + dimensionsHeader + ", dimensions: "+dimensions.Length+ ", dimensionsHeader.transform.childCount: "+ dimensionsHeader.transform.childCount);

        for (int i = 0; i < OverworldData.DimensionsCount; i++)
        {
            dimensions[i] = dimensionsHeader.transform.GetChild(i).gameObject;
            Debug.Log("child: " + dimensions[i]);
            if(i != 0)
            {
                dimensions[i].SetActive(false);
            }
        }

        currenDimension = 1;
    }

    private void Update()
    {
        xCoord.text = x;
        yCoord.text = y;
        dimension.text = dimensionNr;
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
            Fleet fleet = playerScript.GetFleet();
            fleet.ActivateShip(currentButton.ShipButtonNr, playerObj);

            UpdateFleetMenuCoords(playerScript.playerData.ActiveShip.X, playerScript.playerData.ActiveShip.Z);
        }
    }

    public void OnDimensionUp()
    {
        if(currenDimension < OverworldData.DimensionsCount)
        {
            dimensions[currenDimension - 1].SetActive(false);
            currenDimension++;
            dimensions[currenDimension - 1].SetActive(true);
        }
    }

    public void OnDimensionDown()
    {
        if (currenDimension > 1)
        {
            dimensions[currenDimension - 1].SetActive(false);
            currenDimension--;
            dimensions[currenDimension - 1].SetActive(true);
        }
    }

    public void UpdateFleetMenuCoords(int xCoord, int yCoord)
    {
        if(xCoord.ToString().Length < 2)
        {
            x = "0"+ xCoord.ToString();
        }
        else
        {
            x = xCoord.ToString();
        }

        if (yCoord.ToString().Length < 2)
        {
            y = "0" + yCoord.ToString();
        }
        else
        {
            y = yCoord.ToString();
        }
    }

    public void UpdateFleetMenuCoords()
    {
            x = "--";
            y = "--";
    }

    public void UpdateFleetMenuDimension(int dimension)
    {
        dimensionNr = "0" + (dimension + 1).ToString();
    }

    private void CreateShipButtons()
    {
        GameObject buttonObj;
        Button button;

        for (int i = 0; i < OverworldData.FleetSize; i++)
        {
            buttonObj = TMP_DefaultControls.CreateButton(new TMP_DefaultControls.Resources());
            Transform textObject = buttonObj.transform.Find("Text (TMP)");
            Object.Destroy(textObject.gameObject);
            button = buttonObj.GetComponent<Button>();

            CreateButton(buttonObj, button, i);
            DesignButton(button);

            for (int j = 0; j <= i; j++)
            {
                CreateShipPart(buttonObj);
            }
        }
    }

    public void SetFirstSelecetedButton()
    {
        eventSystem.firstSelectedGameObject = firstSelectedButton;
    }

    private void CreateButton(GameObject buttonObj, Button button, int i)
    {
        Transform parentsTransform;

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

        button.transform.SetParent(parentsTransform, false);
        Navigation buttonNavigation = button.navigation;
        buttonNavigation.mode = Navigation.Mode.None;
        buttonObj.AddComponent<ShipButton>();
        buttonObj.GetComponent<ShipButton>().ShipButtonNr = i;
        buttonObj.AddComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;


        if (i == 0)
        {
            firstSelectedButton = buttonObj;
            SetFirstSelecetedButton();
            currentButton = buttonObj.GetComponent<ShipButton>();
        }

        shipButtons[i] = buttonObj;
    }

    private void DesignButton(Button button)
    {
        button.image.type = Image.Type.Simple;
        button.image.sprite = Resources.Load<Sprite>("HUD_Elemente/ButtonElements/Button") as Sprite;
        button.image.SetNativeSize();
        button.transition = Selectable.Transition.SpriteSwap;
        Sprite buttonSelected = Resources.Load<Sprite>("HUD_Elemente/ButtonElements/Selection") as Sprite;

        SpriteState spriteState = new();
        spriteState.selectedSprite = buttonSelected;
        button.spriteState = spriteState;
    }

    private void CreateShipPart(GameObject buttonObj)
    {
        GameObject shipPart = new();
        shipPart.name = "ShipPart";
        shipPart.transform.SetParent(buttonObj.transform, false);
        shipPart.AddComponent<CanvasRenderer>();
        shipPart.AddComponent<Image>().sprite = Resources.Load<Sprite>("HUD_Elemente/ButtonElements/ShipPart") as Sprite;
        Image shipPartImage = shipPart.GetComponent<Image>();
        shipPartImage.type = Image.Type.Simple;
        shipPartImage.preserveAspect = true;
        //shipPartImage.SetNativeSize();

        if (name == "FleetMenu1")
        {
            shipPart.layer = 11;
        }
        else
        {
            shipPart.layer = 12;
        }
    }
}
