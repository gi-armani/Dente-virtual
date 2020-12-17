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

        [Test]
        public void get_item_from_empty_shop_prices()
        {
            // Prepare
            ShopItemsPrices shopPrices = ScriptableObject.CreateInstance<ShopItemsPrices>();

            // Act
            ShopItem returnedItem = shopPrices.GetItem("TestItem");
            int returnedPrice = shopPrices.GetPrice("TestItem");

            // Assert
            // Use the Assert class to test conditions
            Assert.IsNull(returnedItem);
            Assert.AreEqual(0, returnedPrice);

            // Clean Up
            ScriptableObject.DestroyImmediate(shopPrices);
        }

        [Test]
        public void get_item_from_populated_shop_prices()
        {
            // Prepare
            ShopItemsPrices shopPrices = ScriptableObject.CreateInstance<ShopItemsPrices>();


            for (int i = 0; i < 7; i++)
            {
                ShopItem newItem = new ShopItem();
                newItem.itemName = "TestItem" + i;
                newItem.price = 500 + 5 * i;

                shopPrices.ItemList.Add(newItem);
            }

            // Act
            ShopItem existingItem = shopPrices.GetItem("TestItem3");
            int existingItemPrice = shopPrices.GetPrice("TestItem3");

            ShopItem nonExistingItem = shopPrices.GetItem("aaaaaaaaa");
            int nonExistingItemPrice = shopPrices.GetPrice("aaaaaaaaa");

            ShopItem nullStringItem = shopPrices.GetItem(null);
            int nullStringItemPrice = shopPrices.GetPrice(null);

            ShopItem emptyStringItem = shopPrices.GetItem(string.Empty);
            int emptyStringItemPrice = shopPrices.GetPrice(string.Empty);

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(shopPrices.ItemList[3].itemName, existingItem.itemName);
            Assert.AreEqual(shopPrices.ItemList[3].price, existingItem.price);
            Assert.AreEqual(existingItem.price, existingItemPrice);

            Assert.IsNull(nonExistingItem);
            Assert.AreEqual(0, nonExistingItemPrice);

            Assert.IsNull(nullStringItem);
            Assert.AreEqual(0, nullStringItemPrice);

            Assert.IsNull(emptyStringItem);
            Assert.AreEqual(0, emptyStringItemPrice);

            // Clean Up
            ScriptableObject.DestroyImmediate(shopPrices);
        }
    }
}

