using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ShopItemPricesTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void get_existing_item_and_its_price()
        {
            // Prepare
            ShopItemsPrices shopPrices = ScriptableObject.CreateInstance<ShopItemsPrices>();
            ShopItem newItem = new ShopItem();
            newItem.itemName = "TestItem";
            newItem.price = 500;

            shopPrices.ItemList.Add(newItem);

            // Act
            ShopItem returnedItem = shopPrices.GetItem("TestItem");
            int returnedPrice = shopPrices.GetPrice("TestItem");

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(newItem.itemName, returnedItem.itemName);
            Assert.AreEqual(newItem.price, returnedItem.price);
            Assert.AreEqual(returnedItem.price, returnedPrice);

            // Clean Up
            ScriptableObject.DestroyImmediate(shopPrices);
        }

        // [Test]
        // [TestCase(0, 1)]
        // [TestCase(0, -1)]
        // [TestCase(3, -10)]
        // [TestCase(3, 50)]
        // public void add_item_with_quantity(int startAmount, int quantity)
        // {
        //     // Prepare
        //     Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
        //     const string itemName = "item";

        //     if (inventory.GetItem(itemName) == null)
        //         inventory.InventoryList.Add(new Item { itemName = itemName, amount = startAmount });
        //     else
        //         inventory.InventoryList[0] = new Item { itemName = itemName, amount = startAmount };

        //     // Act
        //     inventory.AddValue(itemName, quantity);

        //     // Assert
        //     // Use the Assert class to test conditions
        //     Assert.AreEqual(Mathf.Clamp(startAmount + quantity, 0, 100), inventory.InventoryList[0].amount);

        //     // Clean Up
        //     ScriptableObject.DestroyImmediate(inventory);
        // }
    }
}

