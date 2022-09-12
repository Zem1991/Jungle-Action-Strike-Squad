using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class FeedbackController : AbstractSingleton<FeedbackController>
{
    [Header("Message")]
    [SerializeField] private float timer;
    [SerializeField] private string message;
    public float Timer { get => timer; private set => timer = value; }
    public string Message
    {
        get => message;
        private set
        {
            message = value;
            ResetTimer();
        }
    }

    public bool HasMessage()
    {
        return Timer > 0F && !string.IsNullOrEmpty(Message);
    }
    
    public void SetMessage(string text)
    {
        Message = text;
    }

    private void ResetTimer()
    {
        Timer = 3F;
    }
}
