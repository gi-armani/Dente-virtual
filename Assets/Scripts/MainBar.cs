using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBar : Bar
{
    public BarValues[] BarValuesArray;

    public override void OnEnable()
    {
        UpdateFill();
        foreach (BarValues barValues in BarValuesArray)
        {
            barValues.OnFillChange += UpdateFill;
        }
    }

    public override void OnDisable()
    {
        foreach (BarValues barValues in BarValuesArray)
        {
            barValues.OnFillChange -= UpdateFill;
        }
    }

    public override float CalculateFillAmount()
    {
        if (BarValuesArray.Length <= 0) return 0;

        float sum = 0;

        foreach (BarValues barValues in BarValuesArray)
        {
            sum += barValues.FillPercentage;
        }

        return sum / BarValuesArray.Length;
    }
}
