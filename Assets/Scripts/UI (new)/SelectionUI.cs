using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUI : UIPanel
{
    [Header("SelectionUI Awake")]
    [SerializeField] private SelectionBarUI bar;
    [SerializeField] private SelectionCharacterAbilitiesUI characterAbilities;
    [SerializeField] private SelectionPrimaryAbilitiesUI primaryAbilities;
    [SerializeField] private SelectionSidearmAbilitiesUI sidearmAbilities;
    [SerializeField] private SelectionBackpackAbilitiesUI backpackAbilities;

    protected override void Awake()
    {
        base.Awake();
        bar = GetComponentInChildren<SelectionBarUI>();
        characterAbilities = GetComponentInChildren<SelectionCharacterAbilitiesUI>();
        primaryAbilities = GetComponentInChildren<SelectionPrimaryAbilitiesUI>();
        sidearmAbilities = GetComponentInChildren<SelectionSidearmAbilitiesUI>();
        backpackAbilities = GetComponentInChildren<SelectionBackpackAbilitiesUI>();
    }
    
    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        Character character = SelectionController.Instance.Get();
        if (character)
        {
            bar.Refresh();
            characterAbilities.Refresh();
            primaryAbilities.Refresh();
            sidearmAbilities.Refresh();
            backpackAbilities.Refresh();
            Show();
        }
        else
        {
            Hide();
        }
    }
}
