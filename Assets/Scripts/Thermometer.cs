using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private BarValues barValue;
    [SerializeField] private float lowerLimit = 0.4f;

    Color opaque = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0);

    public bool isSick = false;

    void Update()
    {
        if (barValue.FillPercentage < lowerLimit)
        {
            GetComponent<Image>().color = opaque;
            isSick = true;
        }
        else
        {
            GetComponent<Image>().color = transparent;
            isSick = false;
        }
    }
}
