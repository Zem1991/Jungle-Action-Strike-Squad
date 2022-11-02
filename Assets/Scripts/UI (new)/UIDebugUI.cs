using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugUI : UIPanel
{
    [SerializeField] private Text text;

    public override void Refresh()
    {
        bool hovering = MouseUtils.IsPointerOverUI();
        if (hovering)
        {
            text.text = $"Mouse over UI";
            Show();
        }
        else
        {
            Hide();
        }
    }
}
