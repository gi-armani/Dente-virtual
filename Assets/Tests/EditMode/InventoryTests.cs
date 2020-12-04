using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class inventory_addvalue_tests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void add_value_to_non_existing_item()
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "not_in_list_item";

            // Act
            inventory.AddValue(itemName, 10);

            // Assert
            // Use the Assert class to test conditions
            Assert.IsNull(inventory.GetItem(itemName));
            Assert.AreEqual(inventory.GetQuantity(itemName), 0);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(0, -1)]
        [TestCase(3, -10)]
        [TestCase(3, 50)]
        public void add_item_with_quantity(int startAmount, int quantity)
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "item";

            if(inventory.GetItem(itemName) == null)
                inventory.InventoryList.Add(new Item { itemName = itemName, amount = startAmount });
            else
                inventory.InventoryList[0] = new Item { itemName = itemName, amount = startAmount };

            // Act
            inventory.AddValue(itemName, quantity);

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(Mathf.Clamp(startAmount + quantity, 0, 100), inventory.InventoryList[0].amount);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }

    }
}

