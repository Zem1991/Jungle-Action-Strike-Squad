using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAimHighlight : Highlight
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
        AttackCommand attackCommand = commandController.Current as AttackCommand;
        Character character = commandController.Actor;
        LevelTile targetSlot = commandController.Slot;
        if (attackCommand)
        {
            float range = CombatRules.BALLISTIC_RANGE;
            Vector3 pos1 = character.GetPosition();
            Vector3 cursorWorld = targetSlot.transform.position;
            Vector3 direction = (cursorWorld - pos1).normalized;
            Vector3 pos2 = direction * range + pos1;
            Vector3[] positions = new Vector3[]
            {
                pos1,
                pos2
            };
            lineRenderer.SetPositions(positions);

            float minWidth = 0.1F;
            float spread = character.GetShotSpreadFlat(attackCommand, range);
            lineRenderer.startWidth = minWidth;
            lineRenderer.endWidth = Mathf.Max(spread, minWidth);
            Show();
        }
        else
        {
            Hide();
        }
    }
}
