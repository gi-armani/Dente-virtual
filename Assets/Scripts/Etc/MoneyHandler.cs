using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private Resources resources = default;
    private TextMeshProUGUI textComponent;
    private Color red = new Color(1,0,0,1);
    private Color black = new Color(0,0,0,1);

    public IEnumerator BlinkRed()
    {
        int i = 0;
        while(i < 3)
        {    
            textComponent.color = red;
            yield return new WaitForSeconds(.5f);
            textComponent.color = black;
            yield return new WaitForSeconds(.5f);
            i++;
        }
    }
    
    void OnEnable()
    {
        Resources.MoneyChanged += UpdateMoneyText;
        UpdateMoneyText();
    }

    void OnDisable()
    {
        Resources.MoneyChanged -= UpdateMoneyText;
    }

    public void UpdateMoneyText()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = Convert.ToString(resources.Money);
    }
}
