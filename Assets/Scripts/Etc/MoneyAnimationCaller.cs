using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAnimationCaller : MonoBehaviour
{
    [SerializeField] private Resources resources = default;
    [SerializeField] private Animator coins = default;

    void OnEnable()
    {
        Resources.MoneyAdded += CallAnimation;
    }


    public void CallAnimation()
    {
        coins.SetBool("WonMoney", true);
    }
}
