using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAccuracyUI : TextUI<AbilityInstance>
{
    protected override string GetText(AbilityInstance thing)
    {
        AttackAbilityData attackAbilityData = thing.AbilityData as AttackAbilityData;
        if (!attackAbilityData) return null;
        return $"Accuracy {attackAbilityData.Accuracy}";
    }
}
