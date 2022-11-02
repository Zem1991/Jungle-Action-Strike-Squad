using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SelectionBarUI : UIPanel
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Refresh()
    {
        Character character = SelectionController.Instance.Get();
        Color color = character.Owner.PlayerColorsData.GetUI();
        ChangeBackgroundColor(color);
    }
}
