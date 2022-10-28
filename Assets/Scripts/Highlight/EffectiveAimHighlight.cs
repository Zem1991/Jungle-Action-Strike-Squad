using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveAimHighlight : Highlight
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
        AttackAbilityData attackAbility = abilityController.Current.AbilityData as AttackAbilityData;
        //Character character = abilityController.Actor;
        Character character = abilityController.Current.Actor;
        LevelTile targetTile = abilityController.Tile;
        if (attackAbility)
        {
            float range = character.GetRange();
            Vector3 pos1 = character.GetPosition();
            Vector3 cursorWorld = targetTile.transform.position;
            Vector3 direction = (cursorWorld - pos1).normalized;
            Vector3 pos2 = direction * range + pos1;
            Vector3[] positions = new Vector3[]
            {
                pos1,
                pos2
            };
            lineRenderer.SetPositions(positions);

            float minWidth = 0.1F;
            float spread = character.GetShotSpreadFlat(attackAbility);
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
