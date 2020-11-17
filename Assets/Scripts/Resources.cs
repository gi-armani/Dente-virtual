using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Resources : ScriptableObject
{
    public float Money;

    public void AddValue(int value)
    {   
        if(value > 0)
            Money += value;

    }
}
