using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;
using RoboRyanTron.Unite2017.Events;

public class MedicineItem : DraggableItem
{
    Thermometer thermometer;
    Emote emote;

    [SerializeField] private GameEvent useMedicineWhenSick;
    [SerializeField] private GameEvent useMedicineWhenHealthy;
    
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
                useMedicineWhenSick.Raise();
            }
            else
            {
                StartCoroutine(emote.ShowBalloon(false));
                useMedicineWhenHealthy.Raise();
            }
        }
    }
}
