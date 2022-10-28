using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySet
{
    [Header("Primary")]
    [SerializeField] private Character character;
    public Character Character { get => character; private set => character = value; }

    public AbilitySet(Character character)
    {
        Character = character;
    }

    protected AbilityInstance CreateAbilityInstance(AbilityData abilityData, Item item = null)
    {
        return new AbilityInstance(abilityData, Character, item);
    }

    public abstract AbilityInstance GetFromIndex(int index);
}
