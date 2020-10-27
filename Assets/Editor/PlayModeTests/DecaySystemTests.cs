﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
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
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(barValue.DecayCooldown);

            // Assert
            Assert.AreEqual(1f - barValue.DecayQuantity, barValue.FillPercentage, .00001f, $"Bar value fill is at: {barValue.FillPercentage}");
            LogAssert.Expect(LogType.Log, "Decaying");
            
            // Clean
            GameObject.DestroyImmediate(DecaySystemObject);
            ScriptableObject.DestroyImmediate(barValue);

            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator should_pass_test()
        {
            Assert.Pass();
            yield return null;
        }
    }
}
