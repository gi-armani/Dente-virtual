﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenBuyButton : MonoBehaviour
{
    [SerializeField] private Resources resources = default;
    [SerializeField] private Inventory inventory = default;
    public GameObject caller;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisableCheck);
        GetComponent<Button>().onClick.AddListener(BuyItem);
    }

    public void BuyItem()
    {
        var itemName = caller.transform.parent.name;
        inventory.AddValue(itemName, 1);
    }

    public void DisableCheck()
    {
        caller.GetComponent<Image>().color = Color.clear;
    }
}