﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAnimationCaller : MonoBehaviour
{
    [SerializeField] private Animator coins = default;

    void OnEnable()
    {
        Resources.MoneyAdded += CallAnimation;
    }

    private void OnDisable()
    {
        Resources.MoneyAdded -= CallAnimation;
    }


    public void CallAnimation()
    {
        coins.Play("CoinJump");
    }
}
