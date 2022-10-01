using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public bool CheckActionPoints(Character actor)
    {
        int actionPointsAmount = Mathf.CeilToInt(actor.ActionPoints.PercentToAmount(Data.ActionCostPercent));
        bool actionPointsOK = actor.ActionPoints.CheckEnough(actionPointsAmount);
        //TODO: same for ammo cost
        return actionPointsOK;
    }

    private bool ApplyCosts()
    {
        //if (!CheckCost(Actor)) return false;
        int actionPointsAmount = Mathf.CeilToInt(Actor.ActionPoints.PercentToAmount(Data.ActionCostPercent));
        Actor.SpendActionPoints(actionPointsAmount);
        return true;
    }
}
