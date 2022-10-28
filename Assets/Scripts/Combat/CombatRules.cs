using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatRules
{
    public const float SHOT_SPREAD_ARC = 45F;
    public const float BALLISTIC_RANGE = 150F;

    public static Vector3 AttackDirection(Character actor, AttackAbilityData attackAbility, Vector3 startPos, Vector3 targetPos)
    {
        float degrees = actor.GetShotSpreadArc(attackAbility) / 2F;
        float angle = Random.Range(-degrees, degrees);
        Vector3 result = (targetPos - startPos).normalized;
        result = Quaternion.Euler(0, angle, 0) * result;
        return result;
    }
}
