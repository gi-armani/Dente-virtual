﻿using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class NameHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;
    private const string path = "DentinhoNameFile";

    private void Awake()
    {
        if (File.Exists(GetPath()))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            inputField.onTouchScreenKeyboardStatusChanged.AddListener(ShowButton);
            inputField.onSubmit.AddListener(ShowButton);
            button.onClick.AddListener(SaveName);
        }
    }

    private void ShowButton(TouchScreenKeyboard.Status tsk)
    {
        if(tsk == TouchScreenKeyboard.Status.Done)
            button.gameObject.SetActive(true);
    }

    private void ShowButton(String s)
    {
        button.gameObject.SetActive(true);
    }

    private void SaveName()
    {
        if (!String.IsNullOrEmpty(inputField.text))
        {
            Debug.Log(GetPath());
            File.WriteAllText(GetPath(), inputField.text);
            SceneManager.LoadScene(1);
        }
    }
    
    public static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, path + ".txt");
    }
}
