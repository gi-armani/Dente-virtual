using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FloatVariable : ScriptableObject {
    public float Value;

    public void DecreaseValue(float quantity = 1) {
        if (Value > 0) {
            Value -= quantity;
            if (Value < 0) {
                Value = 0;
            }
        }
    }
}
