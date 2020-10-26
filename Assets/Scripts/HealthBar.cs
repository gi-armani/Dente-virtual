using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BarValues BarValues;

    GameObject fillBar;

    void Awake()
    {
        fillBar = GameObject.FindWithTag("FillBar");
    }

    public void UpdateFill()
    {
        Image img = fillBar.GetComponent<Image>();
        img.fillAmount = BarValues.FillPercentage;
    }

    private void OnEnable()
    {
        UpdateFill();
        BarValues.OnFillChange += UpdateFill;
    }

    private void OnDisable()
    {
        BarValues.OnFillChange -= UpdateFill;
    }
}
