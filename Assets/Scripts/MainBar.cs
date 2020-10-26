using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBar : MonoBehaviour
{
    public BarValues[] BarValuesArray;
    GameObject fillBar;

    void Awake()
    {
        fillBar = GameObject.FindWithTag("FillBar");
    }

    public void UpdateFill()
    {
        if (BarValuesArray.Length <= 0) return;

        Image img = fillBar.GetComponent<Image>();
        float sum = 0;

        foreach (BarValues barValues in BarValuesArray)
        {
            sum += barValues.FillPercentage;
        }

        img.fillAmount = sum / BarValuesArray.Length;
    }

    private void OnEnable()
    {
        UpdateFill();
        foreach (BarValues barValues in BarValuesArray)
        {
            barValues.OnFillChange += UpdateFill;
        }
    }

    private void OnDisable()
    {
        foreach (BarValues barValues in BarValuesArray)
        {
            barValues.OnFillChange -= UpdateFill;
        }
    }
}
