using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private Resources resources = default;
    private TextMeshProUGUI textComponent;

    void OnEnable()
    {
        Resources.MoneyChanged += UpdateMoneyText;
        UpdateMoneyText();
    }

    void OnDisable()
    {
        Resources.MoneyChanged -= UpdateMoneyText;
    }

    public void UpdateMoneyText()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = Convert.ToString(resources.Money);
    }
}
