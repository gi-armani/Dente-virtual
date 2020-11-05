using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;

public class MedicineItem : DraggableItem
{
    Thermometer thermometer;
    Emote emote;

    private void Start()
    {
        thermometer = GameObject.Find("Thermometer").GetComponent<Thermometer>();
        emote = GameObject.Find("Emote").GetComponent<Emote>();
    }

    public override void OnDrop()
    {
        if (!emote.isShowingBalloon)
        {
            if (thermometer.isSick)
            {
                StartCoroutine(emote.ShowBalloon(true));
                UseItem();
            }
            else
            {
                StartCoroutine(emote.ShowBalloon(false));
            }
        }
    }
}
