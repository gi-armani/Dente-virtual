using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private BarValues barValue = default;
    [SerializeField] private float lowerLimit = 0.4f;

    public bool isSick = false;

    void Update()
    {
        if (barValue.FillPercentage < lowerLimit)
        {
            GetComponent<Image>().color = Color.white;
            isSick = true;
        }
        else
        {
            GetComponent<Image>().color = Color.clear;
            isSick = false;
        }
    }
}
