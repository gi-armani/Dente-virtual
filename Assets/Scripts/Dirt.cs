using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dirt : MonoBehaviour
{
    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;

    Image dirtImage;

    public BarValues BarValue;

    public float UpperLimit = 0.6f;
    public float MediumLimit = 0.4f;
    public float LowerLimit = 0.2f;

    public void Start()
    {
        dirtImage = GetComponent<Image>();
    }

    public void Update()
    {
        float percentage = BarValue.FillPercentage;
        if (percentage < LowerLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(true);
            Dirt3.SetActive(true);
        }
        else if (percentage < MediumLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(true);
            Dirt3.SetActive(false);
        }
        else if (percentage < UpperLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(false);
            Dirt3.SetActive(false);
        }
        else
        {
            Dirt1.SetActive(false);
            Dirt2.SetActive(false);
            Dirt3.SetActive(false);
        }
    }
}
