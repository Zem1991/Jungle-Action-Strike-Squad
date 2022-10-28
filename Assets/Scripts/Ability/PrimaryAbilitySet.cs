using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrimaryAbilitySet : AbilitySet
{
    [Header("Primary")]
    [SerializeField] private Item primaryItem;
    [SerializeField] private AbilityInstance ability1;
    [SerializeField] private AbilityInstance ability2;
    [SerializeField] private AbilityInstance overwatch;
    [SerializeField] private AbilityInstance reload;
    public Item PrimaryItem { get => primaryItem; private set => primaryItem = value; }
    public AbilityInstance Ability1 { get => ability1; private set => ability1 = value; }
    public AbilityInstance Ability2 { get => ability2; private set => ability2 = value; }
    public AbilityInstance Overwatch { get => overwatch; private set => overwatch = value; }
    public AbilityInstance Reload { get => reload; private set => reload = value; }

    public PrimaryAbilitySet(Character character) : base(character)
    {
        AbilityDataHandler prefabs = AbilityDataHandler.Instance;

        PrimaryItem = character.GetPrimaryItem();
        RangedWeapon primaryWeapon = PrimaryItem as RangedWeapon;

        Ability1 = CreateAbilityInstance(PrimaryItem.ItemData.Ability1, PrimaryItem);
        Ability2 = CreateAbilityInstance(PrimaryItem.ItemData.Ability2, PrimaryItem);
        if (primaryWeapon)
        {
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
