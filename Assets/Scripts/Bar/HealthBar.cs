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
        if (BarValues != null)
        {
            BarValues.OnFillChange += UpdateFill;
        }
    }

    public override void OnDisable()
    {
        if (BarValues != null)
        {
            BarValues.OnFillChange -= UpdateFill;
        }
    }

    public override float CalculateFillAmount()
    {
        if (BarValues != null)
        {
            return BarValues.FillPercentage;
        }
        return 1f;
    }
}
