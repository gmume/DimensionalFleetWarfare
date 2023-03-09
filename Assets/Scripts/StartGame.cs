using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Dimensions dimensions1;
    //public Dimensions dimensions2;
    public Fleet fleet1;
    //public Fleet fleet2 = new();

    // Start is called before the first frame update
    void Start()
    {
        dimensions1 = ScriptableObject.CreateInstance("Dimensions") as Dimensions;
        dimensions1.CreateDimensions();
        fleet1 = ScriptableObject.CreateInstance("Fleet") as Fleet;

        dimensions1.CreateDimensions();
        Cell cell = dimensions1.GetCell(1, 1, 2);
        Debug.Log("Cell112: " + cell);
        Debug.Log("CellX: " + cell.GetX());
        Debug.Log("CellY: " + cell.GetY());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
