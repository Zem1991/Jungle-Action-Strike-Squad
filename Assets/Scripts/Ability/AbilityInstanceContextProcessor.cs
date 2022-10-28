using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInstanceContextProcessor
{
    public AbilityInstance Process(Character actor)
    {
        LevelTile targetTile = null;
        if (!targetTile) return null;

        Character targetCharacter = targetTile.Character;
        if (!targetCharacter) return AgainstLevelTile(actor, targetTile);
        else if (targetCharacter != actor) return AgainstOther(actor, targetCharacter);
        else return AgainstSelf(actor);
    }

    private AbilityInstance AgainstLevelTile(Character actor, LevelTile target)
    {
        if (target.Character) return ObstructedTile(actor, target);
        else return EmptyTile(actor, target);
    }

    private AbilityInstance AgainstOther(Character actor, Character target)
    {
        if (target.Owner != actor.Owner) return EnemyCharacter(actor, target);
        else return AlliedCharacter(actor, target);
    }

    private AbilityInstance AgainstSelf(Character actor)
    {
        AbilityInstance result;
        ReloadCheck reloadCheck = new();
        if (reloadCheck.CheckPrimary(actor)) result = actor.PrimaryAS.Reload;
        else if (reloadCheck.CheckSidearm(actor)) result = actor.SidearmAS.Reload;
        else result = null;
        return result;
    }

    private AbilityInstance ObstructedTile(Character actor, LevelTile target)
    {
        return null;
    }

    private AbilityInstance EmptyTile(Character actor, LevelTile target)
    {
        AbilityInstance result = actor.CharacterAS.Move;
        return result;
    }

    private AbilityInstance EnemyCharacter(Character actor, Character target)
    {
        AbilityInstance result;
        AttackCheck attackCheck = new();
        if (attackCheck.CheckPrimary(actor)) result = actor.PrimaryAS.Ability1;
        else if (attackCheck.CheckSidearm(actor)) result = actor.SidearmAS.Ability1;
        else result = actor.CharacterAS.UnarmedAttack;
        return result;
    }

    private AbilityInstance AlliedCharacter(Character actor, Character target)
    {
        AbilityInstance result = actor.CharacterAS.Move;
        return result;
    }
}
