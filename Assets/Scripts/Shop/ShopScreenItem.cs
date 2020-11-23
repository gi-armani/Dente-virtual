using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenItem : MonoBehaviour
{
    [SerializeField] private GameObject buyButton;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowButton);
    }

    void ShowButton()
    {
        buyButton.SetActive(true);
    }
}
