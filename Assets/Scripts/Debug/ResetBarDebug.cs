using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBarDebug : MonoBehaviour
{
    public BarValues[] BarValuesArray;

    public void ResetBars()
    {
        foreach (BarValues barValues in BarValuesArray)
        {
            barValues.AddFillPercentage(1);
        }
    }
}
