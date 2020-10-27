﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class DecaySystemTests
    {

        [UnityTest] [Timeout(2000)]
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
            //yield return new WaitForEndOfFrame();
            Debug.Log("Waiting for frame");
            yield return new WaitForEndOfFrame();
            Debug.Log("Frame done");
            yield return new WaitForSeconds(barValue.DecayCooldown);
            Debug.Log("Waited for decay cooldown " + barValue.DecayCooldown);

            // Assert
            Debug.Log("Getting to assertions");
            Assert.AreEqual(1f - barValue.DecayQuantity, barValue.FillPercentage, .00001f, $"Bar value fill is at: {barValue.FillPercentage}");
            Debug.Log("Asserting log messaeg");
            LogAssert.Expect(LogType.Log, "Decaying");

            // Clean
            Debug.Log("Cleaning scene");
            GameObject.DestroyImmediate(DecaySystemObject);
            ScriptableObject.DestroyImmediate(barValue);
            Debug.Log("Done cleaning scene");
            Assert.Pass();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        [UnityTest]
        public IEnumerator should_pass_test()
        {
            Assert.Pass();
            yield return null;
        }

        [UnityTest] [Timeout(2000)]
        public IEnumerator gameobject_creation_test()
        {
            var go = new GameObject();
            yield return null;
            GameObject.Destroy(go);
            Assert.AreEqual(0, 0);
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator gameobject_creation_test_with_unload()
        {
            var go = new GameObject();
            yield return null;
            GameObject.Destroy(go);
            Assert.AreEqual(0, 0);
            Assert.Pass();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
