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

    private void OnDisable()
    {
        buyButton.SetActive(false);
        checkImage.GetComponent<Image>().color = Color.clear;
    }

    void Start()
    {
        checkImage.GetComponent<Image>().color = Color.clear;
        GetComponent<Button>().onClick.AddListener(ShowButton);
    }

    void ShowButton()
    {
        var defaultScript = buyButton.GetComponent<ShopScreenBuyButton>();

        if (defaultScript != null)
        {
            var caller = defaultScript.caller;

            if (caller != null)
            {
                defaultScript.DisableCheck();
            }

            if (!buyButton.activeSelf)
            {
                buyButton.SetActive(true);
                checkImage.GetComponent<Image>().color = opaque;
            }
            else
            {
                buyButton.SetActive(false);
                checkImage.GetComponent<Image>().color = Color.clear;
            }
            
            checkImage.GetComponent<Image>().color = opaque;
            defaultScript.caller = checkImage;
        }
        else
        {
            var clothesScript = buyButton.GetComponent<ClothesScreenBuyButton>();
            var caller = clothesScript.caller;

            if (caller != null)
            {
                clothesScript.DisableCheck();
            }

            if (!buyButton.activeSelf)
            {
                buyButton.SetActive(true);
                checkImage.GetComponent<Image>().color = opaque;
            }
            else
            {
                buyButton.SetActive(false);
                checkImage.GetComponent<Image>().color = Color.clear;
            }

            clothesScript.caller = checkImage;
        }
    }
}
