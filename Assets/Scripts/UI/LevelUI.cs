using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : UIPanel
{
    [SerializeField] private Text text;

    public override void Refresh()
    {
        string refreshText = LevelController.Instance.ReadForUI();
        if (refreshText == null)
        {
            Hide();
        }
        else
        {
            text.text = $"Level: {refreshText}";
            Show();
        }
    }
}
