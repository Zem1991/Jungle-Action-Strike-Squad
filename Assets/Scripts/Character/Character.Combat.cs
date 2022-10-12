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

    private float GetRangedSkill(AttackCommandData attackCommand)
    {
        float result = SkillSet.RangedCombat.Current;
        Weapon weapon = GetMainWeapon();
        if (weapon)
            result *= weapon.ItemData.AccuracyModifier;
        //if (attackCommand)
        //    result *= attackCommand.ItemSkillPercent;
        return result;
    }

    private float GetRangedNoise(AttackCommandData attackCommand)
    {
        float result = GetRangedSkill(attackCommand) / 100F;
        result = Mathf.Clamp01(1 - result);
        return result;
    }

    public float GetShotSpreadArc(AttackCommandData attackCommand)
    {
        float noise = GetRangedNoise(attackCommand);
        float result = CombatRules.SHOT_SPREAD_ARC * noise;
        return result;
    }

    public float GetShotSpreadFlat(AttackCommandData attackCommand)
    {
        float range = GetRange();
        return GetShotSpreadFlat(attackCommand, range);
    }

    public float GetShotSpreadFlat(AttackCommandData attackCommand, float range)
    {
        float angle = GetShotSpreadArc(attackCommand);
        float radians = angle * (Mathf.PI / 180);
        //float radians = angle * Mathf.Deg2Rad;
        float tan = Mathf.Tan(radians);
        float result = range * tan;
        return result;
    }
}
