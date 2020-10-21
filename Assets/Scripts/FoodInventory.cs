using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FoodInventory : GenericInventory
{
    public FoodInventory()
    {
        AddInitialValues();
    }

    private void AddInitialValues()
    {
        Inventory.Add("Apple", 5);
        Inventory.Add("Banana", 8);
        Inventory.Add("Grape", 10);
    }
}