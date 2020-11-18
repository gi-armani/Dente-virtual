using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Resources : ScriptableObject
{
    public int Money;
    public static Action MoneyChanged;

    public void AddMoney(int value)
    {
        Money += value;
        MoneyChanged?.Invoke();
    }

    public void SetMoney(int value)
    {
        Money = value;
        MoneyChanged?.Invoke();
    }
}
