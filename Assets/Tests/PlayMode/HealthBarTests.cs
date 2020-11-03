using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class HealthBarTests
    {
        // Funções pra lidar com o load da cena de teste
        bool sceneLoaded;
        public void LoadTestScene()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
        }
        
        [UnityTest]
        public IEnumerator bar_value_is_being_updated_correctly()
        {
            // Load
            // Carrega a cena de testes
            LoadTestScene();

            // Espera ela carregar
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");

            var barValue = ScriptableObject.CreateInstance<BarValues>();
            barValue.FillPercentage = 0.5f;
            barValue.DecayCooldown = .1f;
            barValue.DecayQuantity = .1f;

            var headerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Header.prefab");
            var header = GameObject.Instantiate(headerPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);
            header.SetActive(false);
            var healthBar = header.GetComponentInChildren<HealthBar>();
            healthBar.BarValues = barValue;
            header.SetActive(true);

            // Act
            barValue.AddFillPercentage(0.2f);

            yield return null;

            // Assert
            Assert.AreEqual(0.7f, barValue.FillPercentage, 0.01f);
        }

        [UnityTest]
        public IEnumerator bar_image_is_being_filled_correctly() {
            // Load
            // Carrega a cena de testes
            LoadTestScene();

            // Espera ela carregar
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");

            var barValue = ScriptableObject.CreateInstance<BarValues>();
            barValue.FillPercentage = 0.5f;
            barValue.DecayCooldown = .1f;
            barValue.DecayQuantity = .1f;

            var headerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Header.prefab");
            var header = GameObject.Instantiate(headerPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);
            header.SetActive(false);
            var healthBar = header.GetComponentInChildren<HealthBar>();
            healthBar.BarValues = barValue;
            header.SetActive(true);

            var fillBar = GameObject.FindWithTag("FillBar");
            Image barImage = fillBar.GetComponent<Image>();

            // Act
            barValue.AddFillPercentage(0.2f);

            yield return null;

            // Assert
            Assert.AreEqual(barValue.FillPercentage, barImage.fillAmount, 0.01f);
        }
    }
}