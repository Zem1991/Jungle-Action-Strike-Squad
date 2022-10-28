using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackpackAbilitySet : AbilitySet
{
    [Header("Backpack")]
    [SerializeField] private AbilityInstance ability1;
    [SerializeField] private AbilityInstance ability2;

    public BackpackAbilitySet(Character character) : base(character)
    {
        throw new System.NotImplementedException();
    }

    public override AbilityInstance GetFromIndex(int index)
    {
        throw new System.NotImplementedException();
    }
}
