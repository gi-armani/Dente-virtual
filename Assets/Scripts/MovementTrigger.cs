using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private GameObject firstTrigger;
    [SerializeField] private GameObject nextTrigger;

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
            // termina o movimento
            Debug.Log("TERMINOU");
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
