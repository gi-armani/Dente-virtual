using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class IntVariable : ScriptableObject
{
    public int Value;

    public void DecreaseValue()
    {
        if (Value > 0)
        {
            Value--;
        }
    }
}
