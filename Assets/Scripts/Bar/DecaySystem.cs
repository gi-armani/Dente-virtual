using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecaySystem : MonoBehaviour
{
    public BarValues[] BarValuesArray = new BarValues[0];
    private void Awake()
    {
        Application.quitting += Application_quitting;
    }

    private void Application_quitting()
    {
        Save(DateTime.Now);
    }

    private void Start()
    {
        Load(DateTime.Now);
        BarSelect();
    }

    private IEnumerator Decay(BarValues BarValue)
    {
        yield return new WaitForSeconds(BarValue.DecayCooldown);
        BarValue.AddFillPercentage(-BarValue.DecayQuantity);
        StartCoroutine(nameof(Decay), BarValue);
    }

    private void BarSelect()
    {
        foreach(BarValues barValues in BarValuesArray)
        {
            StartCoroutine(nameof(Decay), barValues);
        }
    }

    public static readonly string closeDateKey = "LastCloseDateTime";

    public bool Load(DateTime time)
    {
        string closedTimeStr = PlayerPrefs.GetString(closeDateKey, string.Empty/*DateTime.Now.ToUniversalTime().ToString()*/);

        if (string.IsNullOrEmpty(closedTimeStr))
        {
            Debug.LogWarning("Couldn't load closed time");
            return false;
        }

        if(DateTime.TryParse(closedTimeStr, out DateTime closedDateTime))
        {
            time = time.ToUniversalTime();

            double passedTime = (time - closedDateTime).TotalSeconds;
            foreach(BarValues bar in BarValuesArray)
            {
                int decayTimes = Mathf.FloorToInt((float) passedTime / bar.DecayCooldown);
                bar.AddFillPercentage(-bar.DecayQuantity * decayTimes);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Save(DateTime time)
    {
        PlayerPrefs.SetString(closeDateKey, time.ToUniversalTime().ToString());
        PlayerPrefs.Save();
    }
}
