using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Ability")]
    [SerializeField] private PrimaryAbilitySet primaryAS;
    [SerializeField] private SidearmAbilitySet sidearmAS;
    [SerializeField] private BackpackAbilitySet backpackAS;
    [SerializeField] private CharacterAbilitySet characterAS;
    public PrimaryAbilitySet PrimaryAS { get => primaryAS; private set => primaryAS = value; }
    public SidearmAbilitySet SidearmAS { get => sidearmAS; private set => sidearmAS = value; }
    public BackpackAbilitySet BackpackAS { get => backpackAS; private set => backpackAS = value; }
    public CharacterAbilitySet CharacterAS { get => characterAS; private set => characterAS = value; }

    public void RefreshAbilitys()
    {
        PrimaryAS = new PrimaryAbilitySet(this);
        SidearmAS = new SidearmAbilitySet(this);
        BackpackAS = new BackpackAbilitySet(this);
        CharacterAS = new CharacterAbilitySet(this);
    }

    public AbilityInstance GetHotkeyAbility(AbilitySetType abilitySet, int index)
    {
        if (abilitySet == AbilitySetType.PRIMARY) return PrimaryAS.GetFromIndex(index);
        if (abilitySet == AbilitySetType.SIDEARM) return SidearmAS.GetFromIndex(index);
        if (abilitySet == AbilitySetType.BACKPACK) return BackpackAS.GetFromIndex(index);
        if (abilitySet == AbilitySetType.CHARACTER) return CharacterAS.GetFromIndex(index);
        return null;
    }
}
