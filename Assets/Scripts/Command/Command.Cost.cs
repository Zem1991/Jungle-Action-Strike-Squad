using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Command : MonoBehaviour
{
    [Header("Cost")]
    [SerializeField][Min(0)] private int ammoCost;
    [SerializeField][Range(0, 100)] private int actionCostPercent;
    public int AmmoCost { get => ammoCost; private set => ammoCost = value; }
    public int ActionCostPercent { get => actionCostPercent; private set => actionCostPercent = value; }

    public bool CheckActionPoints(Character actor)
    {
        int actionPointsAmount = Mathf.CeilToInt(actor.ActionPoints.PercentToAmount(ActionCostPercent));
        bool actionPointsOK = actor.ActionPoints.CheckEnough(actionPointsAmount);
        //TODO: same for ammo cost
        return actionPointsOK;
    }

    private bool ApplyCosts()
    {
        //if (!CheckCost(Actor)) return false;
        int actionPointsAmount = Mathf.CeilToInt(Actor.ActionPoints.PercentToAmount(ActionCostPercent));
        Actor.SpendActionPoints(actionPointsAmount);
        return true;
    }
}
