using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInstance
{
    [SerializeField] private AbilityData abilityData;
    [SerializeField] private Character actor;
    [SerializeField] private Item item;
    public AbilityData AbilityData { get => abilityData; private set => abilityData = value; }
    public Character Actor { get => actor; private set => actor = value; }
    public Item Item { get => item; private set => item = value; }

    public AbilityInstance(AbilityData abilityData, Character actor, Item item)
    {
        AbilityData = abilityData;
        Actor = actor;
        Item = item;
    }
}
