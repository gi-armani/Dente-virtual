using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Resources : PersistentScriptableObject
{
    public int Money;
    public static Action MoneyChanged;
    public static Action MoneyAdded;

    public void AddMoney(int value)
    {
        Money += value;
        MoneyChanged?.Invoke();
        if (value > 0)
        {
            MoneyAdded?.Invoke();
        }
    }

    public void SetMoney(int value)
    {
        Money = value;
        MoneyChanged?.Invoke();
    }
}
