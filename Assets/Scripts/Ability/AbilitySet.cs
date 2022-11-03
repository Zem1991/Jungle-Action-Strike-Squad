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
        if (!abilityData) return null;
        return new AbilityInstance(abilityData, Character, item);
    }

    public Dictionary<int, AbilityInstance> GetAllIndexed()
    {
        Dictionary<int, AbilityInstance> result = new Dictionary<int, AbilityInstance>();
        //TODO: HARDCODED VALUE HERE
        for (int index = 0; index < 8; index++)
        {
            AbilityInstance abilityInstance = GetFromIndex(index);
            if (abilityInstance == null) continue;
            result.Add(index, abilityInstance);
        }
        return result;
    }

    public abstract AbilityInstance GetFromIndex(int index);
}
