using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : Item
{
    //[Header("Usable Item")]
    //[SerializeField] private UsageType usageType = UsageType.ALLY_OR_SELF;
    //[SerializeField] private AbstractEffect useEffect;
    //[SerializeField] private AbstractEffect thrownEffect;
    //public UsageType UsageType { get => usageType; private set => usageType = value; }
    //public AbstractEffect UseEffect { get => useEffect; private set => useEffect = value; }
    //public AbstractEffect ThrownEffect { get => thrownEffect; private set => thrownEffect = value; }

    //public bool CanUse(Character actor, Vector2 position, Character target)
    //{
    //    //Helper variables
    //    bool targetIsNotActor = actor != target;
    //    bool targetIsAllyOrSelf = actor.IsAllyOf(target);
    //    bool targetIsEnemy = targetIsNotActor && !actor.IsAllyOf(target);
    //    //Return value checks
    //    bool typeItem = UsageType == UsageType.ITEM_ON_FLOOR;
    //    bool typePosition = UsageType == UsageType.POSITION;
    //    bool typeSelf = UsageType == UsageType.SELF && !targetIsNotActor;
    //    bool typeAllyOrSelf = UsageType == UsageType.ALLY_OR_SELF && targetIsAllyOrSelf;
    //    bool typeEnemy = UsageType == UsageType.ENEMY && targetIsEnemy;
    //    return typeItem || typePosition || typeSelf || typeAllyOrSelf || typeEnemy;
    //}

    //public bool Use(Character actor, Vector2 position, Character target)
    //{
    //    bool result = true;
    //    switch (UsageType)
    //    {
    //        case UsageType.ITEM_ON_FLOOR:
    //            if (target) result = false;
    //            break;
    //        case UsageType.POSITION:
    //            if (target) result = false;
    //            break;
    //        case UsageType.SELF:
    //            if (actor != target) result = false;
    //            break;
    //        case UsageType.ALLY_OR_SELF:
    //            //TODO: Check if target is ally
    //            Debug.LogWarning("TODO: Check if target is ally");
    //            break;
    //        case UsageType.ENEMY:
    //            //TODO: Check if target is enemy
    //            Debug.LogWarning("TODO: Check if target is enemy");
    //            break;
    //    }
    //    if (!result) return false;
    //    result = UseEffect.Apply(actor, this, position, target);
    //    return result;
    //}

    //protected override void AfterThrown()
    //{
    //    base.AfterThrown();
    //    if (!HasTag("primed")) return;
    //    Vector2 position = GetPosition();
    //    UseEffect.Apply(Thrower, this, position, null);
    //}
}
