using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CostHelper
{
    public static bool CheckActionPoints(AbilityData abilityData, Character actor)
    {
        int actionPointsAmount = Mathf.CeilToInt(actor.ActionPoints.PercentToAmount(abilityData.ActionCost.Current));
        bool actionPointsOK = actor.ActionPoints.CheckEnough(actionPointsAmount);
        //TODO: same for ammo cost
        return actionPointsOK;
    }

    public static bool ApplyCosts(AbilityData abilityData, Character actor)
    {
        //if (!CheckCost(Actor)) return false;
        int actionPointsAmount = Mathf.CeilToInt(actor.ActionPoints.PercentToAmount(abilityData.ActionCost.Current));
        actor.SpendActionPoints(actionPointsAmount);
        return true;
    }
}
