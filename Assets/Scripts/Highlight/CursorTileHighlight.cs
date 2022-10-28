using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTileHighlight : Highlight
{
    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        LevelTile levelGridSlot = CursorController.Instance.LevelTile;
        if (levelGridSlot)
        {
            transform.position = levelGridSlot.transform.position;
            Show();
        }
        else
        {
            Hide();
        }
    }
}
