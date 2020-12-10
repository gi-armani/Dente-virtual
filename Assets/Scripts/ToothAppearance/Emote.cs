using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emote : MonoBehaviour
{
    [SerializeField] private Sprite happySprite = default;
    [SerializeField] private Sprite angrySprite = default;
    [SerializeField] private float balloonTimer = 1.5f;

    Image balloonImage;
    public bool isShowingBalloon = false;

    void Start()
    {
        balloonImage = GetComponent<Image>();
    }

    public IEnumerator ShowBalloon(bool isHappy)
    {
        isShowingBalloon = true;
        if (isHappy)
        {
            balloonImage.sprite = happySprite;
        }
        else
        {
            balloonImage.sprite = angrySprite;
        }

        balloonImage.color = Color.white;
        yield return new WaitForSeconds(balloonTimer);
        balloonImage.color = Color.clear;
        isShowingBalloon = false;
    }

    private void OnDisable()
    {
        balloonImage.color = Color.clear;
        isShowingBalloon = false;
    }
}
