using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorUI : UIPanel
{
    [SerializeField] private Text text;

    public override void Refresh()
    {
        string refreshText = CursorController.Instance.ReadForUI();
        if (refreshText == null)
        {
            Hide();
        }
        else
        {
            text.text = $"Cursor: {refreshText}";
            Show();
        }
    }
}
