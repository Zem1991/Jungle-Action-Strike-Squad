using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityActionPointsCostUI : TextUI<AbilityInstance>
{
    protected override string GetText(AbilityInstance thing)
    {
        int percent = thing.AbilityData.ActionCost.Current;
        int cost = thing.Actor.ActionPoints.PercentToAmountCeil(percent);
        return $"{cost} AP";
    }
}
