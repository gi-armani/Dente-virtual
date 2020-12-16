using UnityEngine;

public class MedBarFeedback : MonoBehaviour
{
    public BarValues barValues;
    public FeedbackText feedbackText;
    public string feedbackTextString;

    private void OnEnable()
    {
        barValues.OnFillChange += ShowFeedback;
    }

    private void OnDisable()
    {
        barValues.OnFillChange -= ShowFeedback;
    }

    void ShowFeedback()
    {
        if (barValues.FillPercentage <= 0.3f)
        {
            feedbackText.ShowTextWithTime(feedbackTextString);
        }
    }
}