using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SidearmAbilitySet : AbilitySet
{
    [Header("Sidearm")]
    [SerializeField] private Weapon sidearm;
    [SerializeField] private AbilityInstance ability1;
    [SerializeField] private AbilityInstance ability2;
    [SerializeField] private AbilityInstance overwatch;
    [SerializeField] private AbilityInstance reload;
    public Weapon Sidearm { get => sidearm; private set => sidearm = value; }
    public AbilityInstance Ability1 { get => ability1; private set => ability1 = value; }
    public AbilityInstance Ability2 { get => ability2; private set => ability2 = value; }
    public AbilityInstance Overwatch { get => overwatch; private set => overwatch = value; }
    public AbilityInstance Reload { get => reload; private set => reload = value; }

    public SidearmAbilitySet(Character character) : base(character)
    {
        AbilityDataHandler prefabs = AbilityDataHandler.Instance;

        Sidearm = character.GetSidearm();
        if (!Sidearm) return;

        Ability1 = CreateAbilityInstance(Sidearm.ItemData.Ability1, Sidearm);
        Ability2 = CreateAbilityInstance(Sidearm.ItemData.Ability2, Sidearm);

        RangedWeapon rangedSidearm = Sidearm as RangedWeapon;
        if (rangedSidearm)
        {
            Overwatch = CreateAbilityInstance(prefabs.Overwatch, Sidearm);
            Reload = CreateAbilityInstance(prefabs.PrimaryThrow, Sidearm);
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
