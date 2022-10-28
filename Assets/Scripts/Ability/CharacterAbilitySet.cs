using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterAbilitySet : AbilitySet
{
    [Header("Character")]
    [SerializeField] private AbilityInstance move;
    [SerializeField] private AbilityInstance sneak;
    [SerializeField] private AbilityInstance unarmedAttack;
    [SerializeField] private AbilityInstance takedown;
    public AbilityInstance Move { get => move; private set => move = value; }
    public AbilityInstance Sneak { get => sneak; private set => sneak = value; }
    public AbilityInstance UnarmedAttack { get => unarmedAttack; private set => unarmedAttack = value; }
    public AbilityInstance Takedown { get => takedown; private set => takedown = value; }

    public CharacterAbilitySet(Character character) : base(character)
    {
        AbilityDataHandler prefabs = AbilityDataHandler.Instance;

        Move = CreateAbilityInstance(prefabs.Move);
        Sneak = CreateAbilityInstance(prefabs.Sneak);
        UnarmedAttack = CreateAbilityInstance(prefabs.UnarmedAttack);
        Takedown = CreateAbilityInstance(prefabs.Takedown);
    }

    public override AbilityInstance GetFromIndex(int index)
    {
        if (index == 0) return Move;
        if (index == 1) return Sneak;
        if (index == 2) return unarmedAttack;
        if (index == 3) return Takedown;
        return null;
    }
}
