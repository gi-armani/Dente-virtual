using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI feedbackText = default;
    [SerializeField] private float timeToHide = 1f;

    public void ShowFeedBackText(string feedback)
    {
        CancelInvoke(nameof(HideFeedBackText));
        feedbackText.SetText(feedback);
    }

    public void HideFeedBackText()
    {
        feedbackText.SetText(String.Empty);
    }

    public void ShowTextWithTime(string feedback)
    {
        ShowFeedBackText(feedback);
        Invoke(nameof(HideFeedBackText), timeToHide);
    }
}
