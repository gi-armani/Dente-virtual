using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cavity : MonoBehaviour
{
    public Sprite LightCavity;
    public Sprite MediumCavity;
    public Sprite HardCavity;

    Image cavityImage;

    public BarValues BarValue;

    public float UpperLimit = 0.6f;
    public float MediumLimit = 0.4f;
    public float LowerLimit = 0.2f;

    Color opaque = new Color(1, 1, 1, 1);
    Color transparent = new Color(1, 1, 1, 0);

    public void Start()
    {
        cavityImage = GetComponent<Image>();
    }

    public void Update()
    {
        float percentage = BarValue.FillPercentage;
        cavityImage.color = opaque;
        if (percentage < LowerLimit)
        {
            cavityImage.sprite = HardCavity;
        }
        else if (percentage < MediumLimit)
        {
            cavityImage.sprite = MediumCavity;
        }
        else if (percentage < UpperLimit)
        {
            cavityImage.sprite = LightCavity;
        }
        else
        {
            cavityImage.color = transparent;
        }
    }
}
