using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventorySlotUI : UIPanel
{
    [Header("Data")]
    [SerializeField] private InventorySlot slot;
    public InventorySlot Slot { get => slot; private set => slot = value; }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh(InventorySlot slot)
    {
        Slot = slot;
        itemUI.Refresh(this, slot.Current);
    }

    public bool IsFilled()
    {
        return Slot.IsFilled();
    }
}
