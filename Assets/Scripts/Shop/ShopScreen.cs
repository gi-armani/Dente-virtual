﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{

    public GameObject dentinho;

    void OnEnable()
    {
        dentinho.SetActive(false);
    }

    void OnDisable()
    {
        dentinho.SetActive(true);
    }
}
