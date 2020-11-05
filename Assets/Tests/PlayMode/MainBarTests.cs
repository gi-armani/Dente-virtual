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
    public class MainBarTests
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
        public IEnumerator main_bar_average_test()
        {
            // Load
            // Carrega a cena de testes
            LoadTestScene();

            // Espera ela carregar
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");

            var headerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Header.prefab");
            var header = GameObject.Instantiate(headerPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);
            
            header.SetActive(false);

            var healthBarScript = header.GetComponentInChildren<HealthBar>();
            Object.Destroy(healthBarScript);

            var healthBar = header.transform.Find("HealthBar").gameObject;
            var mainBar = healthBar.AddComponent<MainBar>() as MainBar;

            var barValuesArray = new BarValues[3];

            for(int i = 0; i < barValuesArray.Length; i++)
            {
                barValuesArray[i] = ScriptableObject.CreateInstance<BarValues>();
                barValuesArray[i].FillPercentage = 0.1f * (i + 1);
                barValuesArray[i].DecayCooldown = .1f;
                barValuesArray[i].DecayQuantity = .1f;
            }

            mainBar.BarValuesArray = barValuesArray;

            header.SetActive(true);
            
            Assert.AreEqual(0.2f, mainBar.CalculateFillAmount(), 0.01f);
        }

        [UnityTest]
        public IEnumerator main_bar_average_test_changing_a_fill_percentage_value()
        {
            // Load
            // Carrega a cena de testes
            LoadTestScene();

            // Espera ela carregar
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");

            var headerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Header.prefab");
            var header = GameObject.Instantiate(headerPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);
            
            header.SetActive(false);

            var healthBarScript = header.GetComponentInChildren<HealthBar>();
            Object.Destroy(healthBarScript);

            var healthBar = header.transform.Find("HealthBar").gameObject;
            var mainBar = healthBar.AddComponent<MainBar>() as MainBar;

            var barValuesArray = new BarValues[3];

            for(int i = 0; i < barValuesArray.Length; i++){
                barValuesArray[i] = ScriptableObject.CreateInstance<BarValues>();
                barValuesArray[i].FillPercentage = 0.1f * (i + 1);
                barValuesArray[i].DecayCooldown = .1f;
                barValuesArray[i].DecayQuantity = .1f;
            }

            mainBar.BarValuesArray = barValuesArray;

            header.SetActive(true);

            mainBar.BarValuesArray[2].AddFillPercentage(0.3f);
            
            Assert.AreEqual(0.3f, mainBar.CalculateFillAmount(), 0.01f);
        }
    }
}