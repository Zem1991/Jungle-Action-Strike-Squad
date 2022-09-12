using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryController : AbstractSingleton<InventoryController>
{
    [Header("Event")]
    [SerializeField] private InventoryItemUI inventoryItemBeginDrag;
    [SerializeField] private InventorySlotUI inventorySlotPointerEnter;
    public InventoryItemUI InventoryItemBeginDrag { get => inventoryItemBeginDrag; private set => inventoryItemBeginDrag = value; }
    public InventorySlotUI InventorySlotPointerEnter { get => inventorySlotPointerEnter; private set => inventorySlotPointerEnter = value; }

    public void OnBeginDrag(InventoryItemUI inventoryItemUI)
    {
        InventoryItemBeginDrag = inventoryItemUI;
    }

    public void OnPointerEnter(InventorySlotUI inventorySlot)
    {
        InventorySlotPointerEnter = inventorySlot;
    }

    public void OnPointerExit(InventorySlotUI inventorySlot)
    {
        if (InventorySlotPointerEnter == inventorySlot) InventorySlotPointerEnter = null;
    }

    public void OnEndDrag(InventoryItemUI inventoryItem)
    {
        InventoryItemBeginDrag = null;
        if (InventorySlotPointerEnter)
        {
            InventorySlotPointerEnter.Swap(inventoryItem.SlotUI);
            InventorySlotPointerEnter = null;
        }
    }
}
