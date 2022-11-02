using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAimHighlight : AimHighlight
{
    protected override float GetRange(Character character)
    {
        return CombatRules.BALLISTIC_RANGE;
    }

    protected override float GetSpread(Character character, AttackAbilityData attackAbility, float range)
    {
        return character.GetShotSpreadFlat(attackAbility, range);
    }
}
