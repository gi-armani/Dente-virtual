using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    public int moneyReward;
    public GameObject dentinho;
    public GameObject[] Cards;
    private int rows;
    private int cols;
    public int mistakeCounter;
    public GameObject turnedCard1 = null;
    public GameObject turnedCard2 = null;
    public int matchCounter = 0;
    private int victoryMatchGoal = 6;
    public Action mistake;

    [SerializeField] public int maxMistakes = default;
    [SerializeField] private Resources resources = default;

    void OnEnable()
    {
        rows = 4;
        cols = 3;
        mistakeCounter = 0;
        PositionCards();
        dentinho.SetActive(false);
        matchCounter = 0;
    }

    void ResetCards()
    {
        foreach (var card in Cards)
        {
            card.GetComponent<Card>().OnDisable();
            card.GetComponent<Button>().enabled = true;
        }
        matchCounter = 0;
        mistakeCounter = 0;
        PositionCards();
    }

    void OnDisable()
    {
        dentinho.SetActive(true);
        turnedCard1 = null;
        turnedCard2 = null;
        foreach (var card in Cards)
        {
            card.GetComponent<Button>().enabled = true;
        }
    }

    void PositionCards()
    {
        int xInitial = -270;
        int yInitial = 470;

        int xDist = 270;
        int yDist = 300;

        Randomizer.Randomize(Cards);
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 newPosition = new Vector2(xInitial + i * xDist, yInitial - j * yDist);
                GameObject card = Cards[i * rows + j];
                card.transform.localPosition = newPosition;
            }
        }
    }

    public bool CheckIfMatched()
    {
        if (turnedCard1.name == turnedCard2.name)
        {
            matchCounter++;
            if (matchCounter == victoryMatchGoal)
            {
                resources.AddMoney(moneyReward);
            }

            return true;
        }
        else
        {
            mistake?.Invoke();
            if (++mistakeCounter > maxMistakes)
            {
                ResetCards();
            }
        }

        return false;
    }
}




public class Randomizer
{
    public static void Randomize<T>(T[] items)
    {
        System.Random rand = new System.Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
