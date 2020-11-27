using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class LoadName : MonoBehaviour
{
    private static string dentinhoName = String.Empty;
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        if (String.IsNullOrEmpty(dentinhoName))
        {
            if(File.Exists(NameHandler.GetPath()))
                dentinhoName = File.ReadAllText(NameHandler.GetPath());
            else
                dentinhoName = "Dentinho";
        }
        
        
        text.SetText(dentinhoName);
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
}
