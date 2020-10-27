using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecaySystem : MonoBehaviour
{
    public BarValues[] BarValuesArray;
    private void Start()
    {
        BarSelect();
    }

    private IEnumerator Decay(BarValues BarValue)
    {
        yield return new WaitForSeconds(BarValue.DecayCooldown);
        BarValue.AddFillPercentage(-BarValue.DecayQuantity);
        StartCoroutine(nameof(Decay), BarValue);
        Debug.Log("Decaying");
    }

    private void BarSelect()
    {
        foreach(BarValues barValues in BarValuesArray)
        {
            StartCoroutine(nameof(Decay), barValues);
        }
    }

}
