using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI feedbackText = default;
    [SerializeField] private float timeToHide = 1f;

    /// <summary>
    /// Show feedback text string on UI
    /// </summary>
    /// <param name="feedback"></param>
    public void ShowFeedBackText(string feedback)
    {
        CancelInvoke(nameof(HideFeedBackText));
        feedbackText.SetText(feedback);
    }

    /// <summary>
    /// Hide the feedback message text
    /// </summary>
    public void HideFeedBackText()
    {
        feedbackText.SetText(String.Empty);
    }

    /// <summary>
    /// Show feedback text string on UI and hide it after some time
    /// </summary>
    /// <param name="feedback"></param>
    public void ShowTextWithTime(string feedback)
    {
        ShowFeedBackText(feedback);
        Invoke(nameof(HideFeedBackText), timeToHide);
    }

    // Hide text when changing screens
    private void OnDisable()
    {
        CancelInvoke(nameof(HideFeedBackText));
        HideFeedBackText();
    }
}
