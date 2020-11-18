using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    public float YellowUpperLimit = 0.65f;
    public float RedUpperLimit = 0.30f;

    private Color GreenColor = new Color(0, 1, 0, 1);
    private Color YellowColor = new Color(1, 1, 0, 1);
    private Color RedColor = new Color(1, 0, 0, 1);
    GameObject fillBar;

    void Awake()
    {
        fillBar = GameObject.FindWithTag("FillBar");
    }

    public void UpdateFill()
    {
        Image barImage = fillBar.GetComponent<Image>();
        Image iconContainerImage = GameObject.Find("IconContainer").GetComponent<Image>();

        float fillAmount = CalculateFillAmount();
        Color finalColor = CalculateColor(fillAmount);

        barImage.fillAmount = fillAmount;
        barImage.color = finalColor;
        iconContainerImage.color = finalColor;
    }

    Color CalculateColor(float percentage)
    {
        if (percentage < RedUpperLimit)
        {
            return RedColor;
        }
        else if (percentage < YellowUpperLimit)
        {
            return YellowColor;
        }
        else
        {
            return GreenColor;
        }
    }

    public abstract float CalculateFillAmount();
    public abstract void OnEnable();
    public abstract void OnDisable();
}