using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    public BarValues BarValues;

    public override void OnEnable()
    {
        UpdateFill();
        BarValues.OnFillChange += UpdateFill;
    }

    public override void OnDisable()
    {
        BarValues.OnFillChange -= UpdateFill;
    }

    public override float CalculateFillAmount()
    {
        return BarValues.FillPercentage;
    }
}
