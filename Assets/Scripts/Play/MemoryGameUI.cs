using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryGameUI : MonoBehaviour
{
    [SerializeField] private MemoryGame game = default;
    [SerializeField] private TextMeshProUGUI text = default;

    void Awake()
    {
        game.mistake += ManageText;
    }

    private void OnDestroy()
    {
        game.mistake -= ManageText;
    }

    void ManageText()
    {
        StartCoroutine(BlinkRed());
    }

    void Update()
    {
        text.SetText((game.maxMistakes - game.mistakeCounter).ToString());
    }

    public IEnumerator BlinkRed()
    {
        int i = 0;
        while (i < 3)
        {
            text.color = Color.red;
            yield return new WaitForSeconds(.5f);
            text.color = Color.black;
            yield return new WaitForSeconds(.5f);
            i++;
        }
    }


}

