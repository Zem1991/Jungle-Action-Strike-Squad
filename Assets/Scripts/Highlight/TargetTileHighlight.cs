using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTileHighlight : Highlight
{
    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        CommandController commandController = CommandController.Instance;
        LevelTile targetSlot = commandController.Slot;
        if (targetSlot)
        {
            transform.position = targetSlot.transform.position;
            Show();
        }
        else
        {
            Hide();
        }
    }
}
