using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BarValues : PersistentScriptableObject
{
    public float FillPercentage;
    public float DecayCooldown;
    public float DecayQuantity;

    public Action OnFillChange;

    public void AddFillPercentage(float quantity = 0.1f)
    {
        FillPercentage += quantity;
        FillPercentage = Mathf.Clamp(FillPercentage, 0f, 1f);

        OnFillChange?.Invoke();
    }

    public float getFillPercentage()
    {
        return this.FillPercentage;
    }
}
