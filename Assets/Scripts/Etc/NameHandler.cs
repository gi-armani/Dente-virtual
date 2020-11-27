using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class NameHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;
    private const string path = "DentinhoNameFile";

    private void Awake()
    {
        inputField.onTouchScreenKeyboardStatusChanged.AddListener(ShowButton);
        inputField.onSelect.AddListener(arg0 => Debug.Log("testeee"));
        button.onClick.AddListener(SaveName);
    }

    private void ShowButton(TouchScreenKeyboard.Status tsk)
    {
        if(tsk == TouchScreenKeyboard.Status.Done)
            button.gameObject.SetActive(true);
    }

    private void SaveName()
    {
        if (!String.IsNullOrEmpty(inputField.text))
        {
            File.WriteAllText(GetPath(), inputField.text);
        }
    }
    
    private string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, path + ".txt");
    }
}
