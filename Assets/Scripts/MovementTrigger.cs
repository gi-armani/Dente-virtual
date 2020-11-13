using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private GameObject firstTrigger;
    [SerializeField] private GameObject nextTrigger;
    public static Action FinishedMovement;

    void OnEnable()
    {
        ToothBrush.ReleasedToothBrush += ResetTriggers;
    }

    void OnDisable()
    {
        ToothBrush.ReleasedToothBrush -= ResetTriggers;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (nextTrigger == null)
        {
            FinishedMovement?.Invoke();
            ResetTriggers();
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            nextTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void ResetTriggers()
    {
        gameObject.SetActive(false);
        firstTrigger.SetActive(true);
    }
}
