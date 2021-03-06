using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Inventory : PersistentScriptableObject
{
    public List<Item> InventoryList = new List<Item>();

    public void AddValue(string name, int value)
    {
        var item = GetItem(name);
        if (item == null) return;

        int sum = item.amount + value;
        item.amount = Mathf.Clamp(sum, 0, 100);
    }

    public int GetQuantity(string name)
    {
        var item = GetItem(name);
        if (item == null) return 0;

        return item.amount;
    }

    public Item GetItem(string name)
    {
        var item = InventoryList.Find(x => x.itemName == name);
        return item;
    }
}

[System.Serializable]
public class Item
{
    public string itemName;
    public int amount;
    [Range(0, 1)]
    public float healAmount = 0.2f;
    public bool IsHealthy;
}
