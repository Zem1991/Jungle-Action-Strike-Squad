using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackUI : UIPanel
{
    [Header("FeedbackUI Scene")]
    [SerializeField] private Text text;

    public override void Refresh()
    {
        FeedbackController feedbackController = FeedbackController.Instance;
        if (feedbackController.HasMessage())
        {
            text.text = $"{feedbackController.Message}";
            Show();
        }
        else
        {
            Hide();
        }
    }
}
