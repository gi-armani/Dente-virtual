using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesScreenBuyButton : ShopScreenBuyButton
{
    public new void BuyItem()
    {
        var itemName = caller.transform.parent.name;
        var qntItem = inventory.GetQuantity(itemName);
        if (qntItem == 0) base.BuyItem();
    }
}
