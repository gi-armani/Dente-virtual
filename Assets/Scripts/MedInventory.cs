using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MedInventory : GenericInventory
{
    public MedInventory()
    {
        AddInitialValues();
    }

    private void AddInitialValues()
    {
        if (Inventory.Count == 0)
        {
            Inventory.Add("Grape", 5);
            Inventory.Add("Strawberry", 8);
            Inventory.Add("Tuttifruti", 10);
        }
    }
}