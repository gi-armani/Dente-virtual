using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject front;
    private MemoryGame game;

    void Start()
    {
        game = GameObject.FindObjectOfType<MemoryGame>();
        GetComponent<Button>().onClick.AddListener(TurnCard);
    }

    public void TurnCard()
    {
        if (front.activeSelf) return;

        front.SetActive(true);
        if (game.turnedCard1 == null)
        {
            game.turnedCard1 = gameObject;
        }
        else
        {
            game.turnedCard2 = gameObject;
            if (game.CheckIfMatched())
            {
                SetCardsToNull();
            }
            else
            {
                StartCoroutine(nameof(UnturnCards), 1f);
            }
        }
    }

    public void OnDisable()
    {
        front.SetActive(false);
    }

    IEnumerator UnturnCards(float waitTime)
    {
        SetClickStateOnCards(false);

        yield return new WaitForSeconds(waitTime);

        game.turnedCard1?.GetComponent<Card>().front.SetActive(false);
        game.turnedCard2?.GetComponent<Card>().front.SetActive(false);
        SetCardsToNull();
        SetClickStateOnCards(true);
    }

    void SetCardsToNull()
    {
        game.turnedCard1 = null;
        game.turnedCard2 = null;
    }

    void SetClickStateOnCards(bool state)
    {
        foreach (var card in game.Cards)
        {
            card.GetComponent<Button>().enabled = state;
        }
    }
}
