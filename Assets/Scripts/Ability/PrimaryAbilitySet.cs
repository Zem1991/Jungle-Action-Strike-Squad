using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrimaryAbilitySet : AbilitySet
{
    [Header("Primary")]
    [SerializeField] private Item primaryItem;
    [SerializeField] private AbilityInstance ability1 = null;
    [SerializeField] private AbilityInstance ability2 = null;
    [SerializeField] private AbilityInstance overwatch = null;
    [SerializeField] private AbilityInstance reload = null;
    public Item PrimaryItem { get => primaryItem; private set => primaryItem = value; }
    public AbilityInstance Ability1 { get => ability1; private set => ability1 = value; }
    public AbilityInstance Ability2 { get => ability2; private set => ability2 = value; }
    public AbilityInstance Overwatch { get => overwatch; private set => overwatch = value; }
    public AbilityInstance Reload { get => reload; private set => reload = value; }

    public PrimaryAbilitySet(Character character) : base(character)
    {
        ////Fix for Serialization creating empty objects instead of null objects
        //Ability1 = null;
        //Ability2 = null;
        //Overwatch = null;
        //Reload = null;

        PrimaryItem = character.GetPrimaryItem();
        if (!PrimaryItem) return;

        Ability1 = CreateAbilityInstance(PrimaryItem.ItemData.Ability1, PrimaryItem);
        Ability2 = CreateAbilityInstance(PrimaryItem.ItemData.Ability2, PrimaryItem);

        RangedWeapon primaryWeapon = PrimaryItem as RangedWeapon;
        if (primaryWeapon)
        {
            AbilityDataHandler prefabs = AbilityDataHandler.Instance;
            Overwatch = CreateAbilityInstance(prefabs.Overwatch, PrimaryItem);
            Reload = CreateAbilityInstance(prefabs.PrimaryThrow, PrimaryItem);
        }
    }

    public override AbilityInstance GetFromIndex(int index)
    {
        if (index == 0) return Ability1;
        if (index == 1) return Ability2;
        if (index == 2) return Overwatch;
        if (index == 3) return Reload;
        return null;
    }
}
