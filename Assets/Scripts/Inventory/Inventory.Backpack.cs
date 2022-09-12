using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventory : MonoBehaviour
{
    [Header("Backpack")]
    [SerializeField] private InventorySlot backpack1;
    [SerializeField] private InventorySlot backpack2;
    [SerializeField] private InventorySlot backpack3;
    [SerializeField] private InventorySlot backpack4;
    public InventorySlot Backpack1 { get => backpack1; private set => backpack1 = value; }
    public InventorySlot Backpack2 { get => backpack2; private set => backpack2 = value; }
    public InventorySlot Backpack3 { get => backpack3; private set => backpack3 = value; }
    public InventorySlot Backpack4 { get => backpack4; private set => backpack4 = value; }

    public bool Pack(InventorySlot from, InventorySlot to)
    {
        if (to == Backpack1) return ToBackpack1(from);
        if (to == Backpack2) return ToBackpack2(from);
        if (to == Backpack3) return ToBackpack3(from);
        if (to == Backpack4) return ToBackpack4(from);
        return false;
    }

    private bool ToBackpackFree(InventorySlot source)
    {
        InventorySlot bpSlot = GetFreeSlot();
        if (bpSlot == null) return false;
        return SwapSlots(source, bpSlot);
    }

    private bool ToBackpack1(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Backpack1.IsFilled()) return false;
        return SwapSlots(source, Backpack1);
    }

    private bool ToBackpack2(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Backpack2.IsFilled()) return false;
        return SwapSlots(source, Backpack2);
    }

    private bool ToBackpack3(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Backpack3.IsFilled()) return false;
        return SwapSlots(source, Backpack3);
    }

    private bool ToBackpack4(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Backpack4.IsFilled()) return false;
        return SwapSlots(source, Backpack4);
    }

    private InventorySlot GetFreeSlot()
    {
        InventorySlot result = Backpack1;
        if (Backpack1.IsFilled()) result = Backpack2;
        if (Backpack2.IsFilled()) result = Backpack3;
        if (Backpack3.IsFilled()) result = Backpack4;
        if (Backpack4.IsFilled()) result = null;
        return result;
    }
}
