using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class DecaySystemTests
    {
        [UnityTest]
        public IEnumerator decay_system_decrease_fill_quantity_over_time()
        {
            // Prepare Scene
            GameObject DecaySystemObject = new GameObject();
            DecaySystem system = DecaySystemObject.AddComponent<DecaySystem>();

            var barValue = ScriptableObject.CreateInstance<BarValues>();
            barValue.FillPercentage = 1;
            barValue.DecayCooldown = .1f;
            barValue.DecayQuantity = .1f;

            system.BarValuesArray = new BarValues[1] { barValue };

            // Act --> Acts on Start
            yield return null;
            yield return new WaitForSeconds(barValue.DecayCooldown);

            // Assert
            Assert.AreEqual(1f - barValue.DecayQuantity, barValue.FillPercentage, .00001f, $"Bar value fill is at: {barValue.FillPercentage}");

            // Clean
            GameObject.DestroyImmediate(DecaySystemObject);
            ScriptableObject.DestroyImmediate(barValue);
        }
    }
}
