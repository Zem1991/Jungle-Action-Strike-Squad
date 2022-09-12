using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryUI : UIPanel
{
    [Header("Slots: manual references")]
    [SerializeField] private InventorySlotUI primaryItem;
    [SerializeField] private InventorySlotUI sidearm;
    [SerializeField] private InventorySlotUI head;
    [SerializeField] private InventorySlotUI torso;
    [SerializeField] private InventorySlotUI backpack1;
    [SerializeField] private InventorySlotUI backpack2;
    [SerializeField] private InventorySlotUI backpack3;
    [SerializeField] private InventorySlotUI backpack4;

    private void RefreshSlots(Character actor)
    {
        Inventory inventory = actor.Inventory;
        primaryItem.Refresh(inventory.PrimaryItem);
        sidearm.Refresh(inventory.Sidearm);
        head.Refresh(inventory.Head);
        torso.Refresh(inventory.Torso);
        backpack1.Refresh(inventory.Backpack1);
        backpack2.Refresh(inventory.Backpack2);
        backpack3.Refresh(inventory.Backpack3);
        backpack4.Refresh(inventory.Backpack4);
    }
}
