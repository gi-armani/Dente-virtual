using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDebug : MonoBehaviour
{
    [SerializeField] private Resources resources = default;

    public void AddGold()
    {
        resources.AddMoney(100);
    }

    public void ResetGold()
    {
        resources.SetMoney(0);
    }
}
