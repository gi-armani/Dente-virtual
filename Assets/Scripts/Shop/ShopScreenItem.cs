using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScreenItem : MonoBehaviour
{
    [SerializeField] private GameObject buyButton = default;
    [SerializeField] private TextMeshProUGUI text = default;
    [SerializeField] private ShopItemsPrices price = default;
    public GameObject checkImage;
    private Color opaque = new Color(0, 1, 21 / 225, 1);

    void OnEnable()
    {
        text.text = Convert.ToString(price.GetPrice(gameObject.name));
    }

    void Start()
    {
        checkImage.GetComponent<Image>().color = Color.clear;
        GetComponent<Button>().onClick.AddListener(ShowButton);
    }

    void ShowButton()
    {
        var caller = buyButton.GetComponent<ShopScreenBuyButton>().caller;

        if (caller != null)
        {
            buyButton.GetComponent<ShopScreenBuyButton>().DisableCheck();
        }

        buyButton.SetActive(true);
        checkImage.GetComponent<Image>().color = opaque;
        buyButton.GetComponent<ShopScreenBuyButton>().caller = checkImage;
    }
}
