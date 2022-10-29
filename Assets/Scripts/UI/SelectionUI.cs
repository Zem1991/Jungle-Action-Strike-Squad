using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUI : UIPanel
{
    [Header("SelectionUI Awake")]
    [SerializeField] private SelectionBarUI bar;
    [SerializeField] private SelectionProfileUI profile;
    [SerializeField] private SelectionAbilitiesUI abilities;
    [SerializeField] private SelectionEquipmentUI equipment;

    protected override void Awake()
    {
        base.Awake();
        bar = GetComponentInChildren<SelectionBarUI>();
        profile = GetComponentInChildren<SelectionProfileUI>();
        abilities = GetComponentInChildren<SelectionAbilitiesUI>();
        equipment = GetComponentInChildren<SelectionEquipmentUI>();
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
            bar.Refresh(character);
            profile.Refresh(character);
            abilities.Refresh(character);
            equipment.Refresh(character);
            Show();
        }
        else
        {
            Hide();
        }
    }
}
