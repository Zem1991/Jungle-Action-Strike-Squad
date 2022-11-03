using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackpackAbilitySet : AbilitySet
{
    [Header("Backpack")]
    [SerializeField] private AbilityInstance ability1 = null;
    [SerializeField] private AbilityInstance ability2 = null;

    public BackpackAbilitySet(Character character) : base(character)
    {
        Debug.LogWarning("TODO BackpackAbilitySet");
    }

    public override AbilityInstance GetFromIndex(int index)
    {
        Debug.LogWarning("TODO GetFromIndex");
        return null;
    }
}
