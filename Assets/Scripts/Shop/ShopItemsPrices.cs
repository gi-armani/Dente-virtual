using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShopItemsPrices : PersistentScriptableObject
{
    public List<ShopItem> ItemList = new List<ShopItem>();

    public int GetPrice(string name)
    {
        var item = ItemList.Find(x => x.itemName == name);
        return item.price;
    }
    public ShopItem GetItem(string name)
    {
        var item = ItemList.Find(x => x.itemName == name);
        return item;
    }
}

[System.Serializable]
public class ShopItem
{
    public string itemName;
    public int price;

}