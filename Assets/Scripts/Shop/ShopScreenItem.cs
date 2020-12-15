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
            var lastSelectedItem = defaultScript.caller;
            var currentSelectedItem = checkImage;

            if(lastSelectedItem == currentSelectedItem){
                if(IsCurrentItemCheckEnabled()){
                    DisableCheckImage(currentSelectedItem);
                    buyButton.SetActive(false);
                } else {
                    buyButton.SetActive(true);
                    EnableCheckImage(currentSelectedItem);
                }
            } else {
                DisableCheckImage(lastSelectedItem);
                buyButton.SetActive(true);
                EnableCheckImage(currentSelectedItem);
            }

            defaultScript.caller = currentSelectedItem;
        }
        else
        {
            var clothesScript = buyButton.GetComponent<ClothesScreenBuyButton>();
            var lastSelectedItem = clothesScript.caller;
            var currentSelectedItem = checkImage;

            if(lastSelectedItem == currentSelectedItem){
                if(IsCurrentItemCheckEnabled()){
                    DisableCheckImage(currentSelectedItem);
                    buyButton.SetActive(false);
                } else {
                    buyButton.SetActive(true);
                    EnableCheckImage(currentSelectedItem);
                }
            } else {
                DisableCheckImage(lastSelectedItem);
                buyButton.SetActive(true);
                EnableCheckImage(currentSelectedItem);
            }

            clothesScript.caller = currentSelectedItem;
        }
    }

    private void EnableCheckImage(GameObject image){
        if(image) image.GetComponent<Image>().color = opaque;
    }

    private void DisableCheckImage(GameObject image){
        if(image) image.GetComponent<Image>().color = Color.clear;
    }

    private bool IsCurrentItemCheckEnabled(){
        return checkImage.GetComponent<Image>().color == opaque;
    }
}
