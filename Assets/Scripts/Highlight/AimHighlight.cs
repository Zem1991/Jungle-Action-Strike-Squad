using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimHighlight : Highlight
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
        AttackAbilityData attackAbility = abilityController.Current?.AbilityData as AttackAbilityData;
        //Character character = abilityController.Actor;
        if (attackAbility)
        {
            Character character = abilityController.Current.Actor;
            LevelTile targetTile = abilityController.Tile;

            float range = GetRange(character);
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
            float spread = GetSpread(character, attackAbility, range);
            lineRenderer.startWidth = minWidth;
            lineRenderer.endWidth = Mathf.Max(spread, minWidth);
            Show();
        }
        else
        {
            Hide();
        }
    }

    protected abstract float GetRange(Character character);
    protected abstract float GetSpread(Character character, AttackAbilityData attackAbility, float range);
}
