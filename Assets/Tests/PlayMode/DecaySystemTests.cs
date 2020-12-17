using System;
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
            PlayerPrefs.DeleteKey(DecaySystem.closeDateKey);
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

        private static float[] times = { 1.5f, 3f, 5.75f, 1.3f, 1.8f, 3.1f, 2f, 1f };
        [UnityTest]
        public IEnumerator is_decaying_multiple_times([ValueSource("times")] float time)
        {
            PlayerPrefs.DeleteKey(DecaySystem.closeDateKey);
            // Prepare Scene
            GameObject DecaySystemObject = new GameObject();
            DecaySystem system = DecaySystemObject.AddComponent<DecaySystem>();
            var initialFillPercentage = 1f;

            var barValue = ScriptableObject.CreateInstance<BarValues>();
            barValue.FillPercentage = initialFillPercentage;
            barValue.DecayCooldown = 1f;
            barValue.DecayQuantity = .1f;

            system.BarValuesArray = new BarValues[1] { barValue };
            
            // Act --> Acts on Start
            yield return null; 
            yield return new WaitForSeconds((barValue.DecayCooldown * time) + (0.01f * barValue.DecayCooldown));

            //Assert
            var amountDecayed = barValue.DecayQuantity * Mathf.Floor(time);
            Assert.AreEqual(initialFillPercentage - amountDecayed, barValue.FillPercentage, 0.001f);
            
            // Clean
            GameObject.DestroyImmediate(DecaySystemObject);
            ScriptableObject.DestroyImmediate(barValue);
        }
        
        [UnityTest]
        public IEnumerator are_multiple_bars_decaying()
        {
            PlayerPrefs.DeleteKey(DecaySystem.closeDateKey);
            // Prepare Scene
            GameObject DecaySystemObject = new GameObject();
            DecaySystem system = DecaySystemObject.AddComponent<DecaySystem>();
            var initialFillPercentage = 1f;

            
            BarValues[] barValues = new BarValues[3];
            for (int i = 0; i < barValues.Length; i++)
            {
                barValues[i] = ScriptableObject.CreateInstance<BarValues>();
                barValues[i].FillPercentage = initialFillPercentage;
                barValues[i].DecayCooldown = .1f * (i + 1);
                barValues[i].DecayQuantity = .1f * (i + 1);
            }

            system.BarValuesArray = barValues;

            // Act --> Acts on Start
            var maxCooldown = .1f * barValues.Length;
            yield return null;
            yield return new WaitForSeconds(maxCooldown + (0.01f * barValues[0].DecayCooldown));
            
            for (int i = 0; i < barValues.Length; i++)
            {
                // Assert
                var amountDecayed = barValues[i].DecayQuantity * Mathf.Floor(maxCooldown/barValues[i].DecayCooldown);
                Assert.AreEqual(initialFillPercentage - amountDecayed,
                    system.BarValuesArray[i].FillPercentage, .00001f);
            }

            // Clean
            GameObject.DestroyImmediate(DecaySystemObject);
            for (int i = 0; i < barValues.Length; i++)
            {
                ScriptableObject.DestroyImmediate(barValues[i]);
            }
        }
    }
}
