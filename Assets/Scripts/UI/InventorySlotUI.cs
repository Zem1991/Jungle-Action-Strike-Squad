using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventorySlotUI : UIPanel
{
    [Header("Self references")]
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private InventoryItemUI itemUI;

    protected override void Awake()
    {
        inventoryUI = GetComponentInParent<InventoryUI>();
        itemUI = GetComponentInChildren<InventoryItemUI>();
    }

    public void Swap(InventorySlotUI source)
    {
        inventoryUI.Swap(source, this);
    }
}
