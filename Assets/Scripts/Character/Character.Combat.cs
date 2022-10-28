using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    public float GetRange()
    {
        float result = 1F;
        Weapon weapon = GetMainWeapon();
        if (weapon) result = weapon.ItemData.Range;
        return result;
    }

    private float GetRangedSkill(AttackAbilityData attackAbility)
    {
        float result = SkillSet.RangedCombat.Current;
        Weapon weapon = GetMainWeapon();
        if (weapon)
            result *= weapon.ItemData.AccuracyModifier;
        //if (attackAbility)
        //    result *= attackAbility.ItemSkillPercent;
        return result;
    }

    private float GetRangedNoise(AttackAbilityData attackAbility)
    {
        float result = GetRangedSkill(attackAbility) / 100F;
        result = Mathf.Clamp01(1 - result);
        return result;
    }

    public float GetShotSpreadArc(AttackAbilityData attackAbility)
    {
        float noise = GetRangedNoise(attackAbility);
        float result = CombatRules.SHOT_SPREAD_ARC * noise;
        return result;
    }

    public float GetShotSpreadFlat(AttackAbilityData attackAbility)
    {
        float range = GetRange();
        return GetShotSpreadFlat(attackAbility, range);
    }

    public float GetShotSpreadFlat(AttackAbilityData attackAbility, float range)
    {
        float angle = GetShotSpreadArc(attackAbility);
        float radians = angle * (Mathf.PI / 180);
        //float radians = angle * Mathf.Deg2Rad;
        float tan = Mathf.Tan(radians);
        float result = range * tan;
        return result;
    }
}
