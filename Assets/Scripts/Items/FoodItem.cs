using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;
using RoboRyanTron.Unite2017.Events;

public class FoodItem : DraggableItem
{
    Emote emote;
    [SerializeField] private GameEvent healthFoodGiven = default;
    [SerializeField] private GameEvent unhealthFoodGiven = default;
    [SerializeField] private Resources resources = default;
    [SerializeField] private int moneyReward = default;

    private void Start()
    {
        emote = GameObject.Find("Emote").GetComponent<Emote>();
    }
    public override void OnDrop()
    {
        var item = Inventory.GetItem(gameObject.name);
        if (!emote.isShowingBalloon)
        {
            UseItem();
            if (item.IsHealthy)
            {
                resources.AddMoney(moneyReward);
                StartCoroutine(emote.ShowBalloon(true));
                healthFoodGiven.Raise();
            }
            else
            {
                StartCoroutine(emote.ShowBalloon(false));
                unhealthFoodGiven.Raise();
            }
        }
    }
}
