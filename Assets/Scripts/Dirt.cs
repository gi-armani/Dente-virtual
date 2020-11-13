using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dirt : MonoBehaviour
{
    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;

    public Color LowDirtColor;
    public Color MediumDirtColor;
    public Color HighDirtColor;
    private Color NoDirtColor;

    public BarValues BarValue;

    public float UpperLimit = 0.6f;
    public float MediumLimit = 0.4f;
    public float LowerLimit = 0.2f;

    Image dentinhoImage;

    public void Start()
    {
        dentinhoImage = transform.parent.gameObject.GetComponent<Image>();
        NoDirtColor = new Color(1, 1, 1, 1);
    }

    public void Update()
    {
        float percentage = BarValue.FillPercentage;
        if (percentage < LowerLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(true);
            Dirt3.SetActive(true);
            dentinhoImage.color = HighDirtColor;
        }
        else if (percentage < MediumLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(true);
            Dirt3.SetActive(false);
            dentinhoImage.color = MediumDirtColor;
        }
        else if (percentage < UpperLimit)
        {
            Dirt1.SetActive(true);
            Dirt2.SetActive(false);
            Dirt3.SetActive(false);
            dentinhoImage.color = LowDirtColor;
        }
        else
        {
            Dirt1.SetActive(false);
            Dirt2.SetActive(false);
            Dirt3.SetActive(false);
            dentinhoImage.color = NoDirtColor;
        }
    }
}
