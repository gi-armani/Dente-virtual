using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BarValues : ScriptableObject {
    public float FillPercentage;
    public float DecayCooldown;
    public float DecayQuantity;

    public void AddFillPercentage(float quantity = 0.1f) {
        FillPercentage += quantity;

        if (FillPercentage < 0) {
            FillPercentage = 0;
        }
        else if (FillPercentage > 1) {
            FillPercentage = 1;
        }
    }
}
