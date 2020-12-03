using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesScreenBuyButton : MonoBehaviour
{
    [SerializeField] private Resources resources = default;
    public Wardrobe wardrobe = default;
    [SerializeField] private ShopItemsPrices prices = default;
    [SerializeField] private MoneyHandler money = default;
    [SerializeField] private ShowIsEmptyMessage emptyMessageDisplayer = default;
    public GameObject caller;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyItem);
    }

    public void BuyItem()
    {
        var itemName = caller.transform.parent.name;
        var price = prices.GetPrice(itemName);

        if(resources.Money >= price)
        {
            if(!wardrobe.PlayerHas(itemName)){
                resources.AddMoney(-(price));
                wardrobe.AddClothes(itemName);

                bool isDev = true;
                if(isDev){
                    caller.transform.parent.gameObject.SetActive(false);
                } else{
                    Object.Destroy(caller.transform.parent.gameObject);
                }

                emptyMessageDisplayer.ShowMessage();
            }
        }
        else
        {
            StartCoroutine(money.BlinkRed());
        }
    }

    public void DisableCheck()
    {
        caller.GetComponent<Image>().color = Color.clear;
    }
}
