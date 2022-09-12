using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUI : UIPanel
{
    [SerializeField] private Text text;

    public override void Refresh()
    {
        string refreshText = ActionController.Instance.ReadForUI();
        if (refreshText == null)
        {
            Hide();
        }
        else
        {
            text.text = $"Action: {refreshText}";
            Show();
        }
    }
}
