using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BarValuesTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void clamp_on_max_value()
        {
            // Prepare
            BarValues barValues = ScriptableObject.CreateInstance<BarValues>();
            barValues.FillPercentage = 1f;

            // Act
            barValues.AddFillPercentage(2f);

            // Assert
            Assert.AreEqual(1f, barValues.FillPercentage, 0.01f);

            // Clean Up
            ScriptableObject.DestroyImmediate(barValues);
        }

        [Test]
        public void clamp_on_min_value()
        {
            // Prepare
            BarValues barValues = ScriptableObject.CreateInstance<BarValues>();
            barValues.FillPercentage = 1f;

            // Act
            barValues.AddFillPercentage(-2f);

            // Assert
            Assert.AreEqual(0f, barValues.FillPercentage, 0.01f);

            // Clean Up
            ScriptableObject.DestroyImmediate(barValues);
        }

        [Test]
        [TestCase(-0.2f)]
        [TestCase(-0.5f)]
        [TestCase(0.3f)]
        public void fillPercentage_change(float quantity)
        {
            // Prepare
            BarValues barValues = ScriptableObject.CreateInstance<BarValues>();
            barValues.FillPercentage = 0.5f;

            // Act
            barValues.AddFillPercentage(quantity);

            // Assert
            Assert.AreEqual(0.5f + quantity, barValues.FillPercentage, 0.01f);

            // Clean Up
            ScriptableObject.DestroyImmediate(barValues);
        }

        [Test]
        public void invoking_OnFillChange_event()
        {
            // Prepare
            bool wasInvoked = false;

            BarValues barValues = ScriptableObject.CreateInstance<BarValues>();
            barValues.FillPercentage = 1f;
            barValues.OnFillChange += () => wasInvoked = true;

            // Act
            barValues.AddFillPercentage(-.2f);

            // Assert
            Assert.True(wasInvoked);

            // Clean Up
            ScriptableObject.DestroyImmediate(barValues);
        }
    }
}