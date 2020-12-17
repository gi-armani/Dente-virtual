using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BarValuesOfflineTest
    {
        [Test]
        [TestCase(1f)]
        [TestCase(10f)]
        [TestCase(20f)]
        [TestCase(23f)]
        [TestCase(35f)]
        [TestCase(100f)]
        [TestCase(9999f)]
        public void offline_decay_test(float secondsFromStart)
        {
            // Prepare
            const int numBarValues = 3;
            DecaySystem decaySystem = new DecaySystem();
            BarValues[] barValues = new BarValues[numBarValues];

            const float initialFillPercentage = 1f;
            for (int i = 0; i < numBarValues; i++)
            {
                barValues[i] = ScriptableObject.CreateInstance<BarValues>();
                barValues[i].FillPercentage = initialFillPercentage;
                barValues[i].DecayCooldown = 10f * (i + 1);
                barValues[i].DecayQuantity = .1f * (i + 1);
            }
            

            decaySystem.BarValuesArray = barValues;

            // ACT
            DateTime dateTime = DateTime.Now;
            decaySystem.Save(dateTime);

            dateTime = dateTime.AddSeconds(secondsFromStart);

            decaySystem.Load(dateTime);

            foreach(BarValues bar in decaySystem.BarValuesArray)
            {
                float expectedPercentage = initialFillPercentage - 
                    (bar.DecayQuantity * Mathf.FloorToInt(secondsFromStart / bar.DecayCooldown));
                expectedPercentage = Mathf.Clamp01(expectedPercentage);
                Assert.AreEqual(expectedPercentage, bar.getFillPercentage(), 0.01f);
            }

        }

        [Test]
        public void load_without_saving()
        {
            DecaySystem decaySystem = new DecaySystem();

            PlayerPrefs.DeleteKey(DecaySystem.closeDateKey);

            Assert.IsFalse(decaySystem.Load(DateTime.Now));
        }

        [Test]
        public void load_after_saving()
        {
            DecaySystem decaySystem = new DecaySystem();

            decaySystem.Save(DateTime.Now);
            Assert.IsTrue(decaySystem.Load(DateTime.Now));
        }
    }
}