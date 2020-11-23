using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenBuyButton : MonoBehaviour
{
    public GameObject caller;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisableCheck);
    }

    public void DisableCheck()
    {
        caller.GetComponent<Image>().color = Color.clear;
    }
    void Update()
    {
        
    }
}
