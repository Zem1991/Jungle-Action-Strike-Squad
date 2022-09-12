using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEquipmentUI : UIPanel
{
    [Header("SelectionEquipmentUI Awake")]
    [SerializeField] private InventoryButtonUI inventoryButton;

    protected override void Awake()
    {
        base.Awake();
        inventoryButton = GetComponentInChildren<InventoryButtonUI>();
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(Character character)
    {
        ChangeBackgroundColor(character);
        inventoryButton.Refresh(character);
    }
}
