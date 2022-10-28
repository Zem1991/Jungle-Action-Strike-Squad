using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTileHighlight : Highlight
{
    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        AbilityController abilityController = AbilityController.Instance;
        LevelTile targetTile = abilityController.Tile;
        if (targetTile)
        {
            transform.position = targetTile.transform.position;
            Show();
        }
        else
        {
            Hide();
        }
    }
}
