using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GenericInventory : ScriptableObject
{
    public Dictionary<string, int> Inventory = new Dictionary<string, int>();
    
    public void AddValue(string name, int value)
    {
        int sum = Inventory[name] + value;
        Inventory[name] = Mathf.Clamp(sum, 0, 100);

        //OnFillChange?.Invoke();
    }

    public int GetQuantity(string name)
    {
        return Inventory[name];
    }
}