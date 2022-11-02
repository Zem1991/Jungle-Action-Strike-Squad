using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPrimaryAbilitiesUI : SelectionSectionUI
{
    [Header("SelectionCharacterAbilitiesUI Awake")]
    [SerializeField] protected ItemBasicsUI itemBasics;

    protected override void Awake()
    {
        base.Awake();
        itemBasics = GetComponentInChildren<ItemBasicsUI>();
    }

    public override void Refresh()
    {
        base.Refresh();
        Item item = Character.GetPrimaryItem();
        itemBasics.Refresh(item);
    }

    protected override AbilitySet GetAbilitySet()
    {
        return Character.PrimaryAS;
    }
}
