using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUI : UIPanel
{
    [Header("SelectionUI Awake")]
    [SerializeField] private SelectionBarUI bar;
    [SerializeField] private SelectionProfileUI profile;
    [SerializeField] private SelectionCommandsUI commands;
    [SerializeField] private SelectionEquipmentUI equipment;

    protected override void Awake()
    {
        base.Awake();
        bar = GetComponentInChildren<SelectionBarUI>();
        profile = GetComponentInChildren<SelectionProfileUI>();
        commands = GetComponentInChildren<SelectionCommandsUI>();
        equipment = GetComponentInChildren<SelectionEquipmentUI>();
    }
    
    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
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
            commands.Refresh(character);
            equipment.Refresh(character);
            Show();
        }
        else
        {
            Hide();
        }
    }
}
