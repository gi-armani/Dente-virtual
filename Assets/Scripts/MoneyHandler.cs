using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    public Resources resources;
    private TextMeshProUGUI textComponent;

    void OnEnable()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = Convert.ToString(resources.Money);
    }

}
