using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveAimHighlight : AimHighlight
{
    protected override float GetRange(Character character)
    {
        return character.GetRange();
    }

    protected override float GetSpread(Character character, AttackAbilityData attackAbility, float range)
    {
        return character.GetShotSpreadFlat(attackAbility);
    }
}
