using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject front;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TurnCard);
    }

    public void TurnCard()
    {
        front.SetActive(true);
    }

    private void OnDisable()
    {
        front.SetActive(false);
    }
}
