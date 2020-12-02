using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Wardrobe : PersistentScriptableObject
{
    public List<ClothesItem> WardrobeList = new List<ClothesItem>();

    public void AddClothes(string name)
    {
        var item = GetItem(name);
        if (item == null) return;

        item.has = true;
    }

    public bool PlayerHas(string name)
    {
        var item = GetItem(name);
        if (item == null) return false;

        return item.has;
    }

    public ClothesItem GetItem(string name)
    {
        var item = WardrobeList.Find(x => x.itemName == name);
        return item;
    }
}

[System.Serializable]
public class ClothesItem
{
    public string itemName;
    public bool has;
    public Color itemColor;
    public ClotheItems.ClothesType type;
}
