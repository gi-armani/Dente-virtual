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
    public class ChangeScreenTests
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
        public IEnumerator change_screen_with_screen_to_open_assigned()
        {
            // Load
            // Carrega a cena de testes
            LoadTestScene();

            // Espera ela carregar
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");
            var canvas = GameObject.Find("Canvas");

            // Pega uma referência ao prefab do botão, que já tem o script de change screen attachado
            var buttonPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Button.prefab");
            // Instancia o botão na cena, como filho do currentScreen
            var button = GameObject.Instantiate(buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);

            // Pega referência ao prefab do TestScreen
            var testScreenPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScreen.prefab");
            // Instancia uma TestScreen como filha do Canvas
            var screenToOpen = GameObject.Instantiate(testScreenPrefab, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);

            // Garante que a screen atual tá ativa e a screen pra abrir tá desativada
            currentScreen.SetActive(true);
            screenToOpen.SetActive(false);

            // Define a test screen que a gente criou como sendo a screen pra ser aberta ao clicar no botão
            button.GetComponent<ChangeScreen>().screenToOpen = screenToOpen;

            // Espera um frame pra tudo se ajeitar bonitinho
            yield return null;

            // Act
            // Clica no botão
            button.GetComponent<Button>().onClick.Invoke();

            // Assert
            // Checa se a screen que a gente tava ficou desativada e se a nova screen ficou ativa
            Assert.IsFalse(currentScreen.activeSelf);
            Assert.IsTrue(screenToOpen.activeSelf);
        }

        [UnityTest]
        public IEnumerator change_screen_with_screen_to_open_unassigned()
        {
            // Load
            LoadTestScene();
            yield return new WaitWhile(() => sceneLoaded == false);

            // Prepare
            var currentScreen = GameObject.Find("TestScreen");
            var canvas = GameObject.Find("Canvas");

            var buttonPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Button.prefab");
            var button = GameObject.Instantiate(buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity, currentScreen.transform);

            var testScreenPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScreen.prefab");
            var screenToOpen = GameObject.Instantiate(testScreenPrefab, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);

            currentScreen.SetActive(true);
            screenToOpen.SetActive(false);

            button.GetComponent<ChangeScreen>().screenToOpen = null;

            yield return null;

            // Act
            button.GetComponent<Button>().onClick.Invoke();

            // Assert
            Assert.IsTrue(currentScreen.activeSelf);
            Assert.IsFalse(screenToOpen.activeSelf);
        }
    }
}