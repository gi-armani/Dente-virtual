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
        public void add_1_to_item_with_0_quantity()
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "item";
            inventory.InventoryList.Add(new Item { itemName = itemName, amount = 0 });

            // Act
            inventory.AddValue(itemName, 1);

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(inventory.InventoryList[0].amount, 1);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }

        [Test]
        public void add_negative_1_to_item_with_0_quantity()
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "item";
            inventory.InventoryList.Add(new Item { itemName = itemName, amount = 0 });

            // Act
            inventory.AddValue(itemName, -1);

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(inventory.InventoryList[0].amount, 0);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }

        [Test]
        public void add_negative_10_to_item_with_3_quantity()
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "item";
            inventory.InventoryList.Add(new Item { itemName = itemName, amount = 3 });

            // Act
            inventory.AddValue(itemName, -10);

            // Assert
            // Use the Assert class to test conditions
            // Should be 0 are not be changed?
            Assert.AreEqual(inventory.InventoryList[0].amount, 0);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }

        [Test]
        public void add_50_to_item_with_3_quantity()
        {
            // Prepare
            Inventory inventory = ScriptableObject.CreateInstance<Inventory>();
            const string itemName = "item";
            inventory.InventoryList.Add(new Item { itemName = itemName, amount = 3 });

            // Act
            inventory.AddValue(itemName, 50);

            // Assert
            // Use the Assert class to test conditions
            Assert.AreEqual(inventory.InventoryList[0].amount, 53);

            // Clean Up
            ScriptableObject.DestroyImmediate(inventory);
        }
    }
}

