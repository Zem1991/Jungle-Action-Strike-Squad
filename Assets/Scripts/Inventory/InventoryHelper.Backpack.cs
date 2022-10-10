using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class InventoryHelper
{
    public static bool Pack(Inventory fromInv, InventorySlot fromSlot, InventorySlot toSlot)
    {
        if (toSlot == fromInv.Backpack1) return ToBackpack1(fromInv, fromSlot);
        if (toSlot == fromInv.Backpack2) return ToBackpack2(fromInv, fromSlot);
        if (toSlot == fromInv.Backpack3) return ToBackpack3(fromInv, fromSlot);
        if (toSlot == fromInv.Backpack4) return ToBackpack4(fromInv, fromSlot);
        return false;
    }

    private static bool ToBackpackFree(Inventory fromInv, InventorySlot sourceSlot)
    {
        InventorySlot bpSlot = GetFreeSlot(fromInv);
        if (bpSlot == null) return false;
        return SwapSlots(sourceSlot, bpSlot);
    }

    private static bool ToBackpack1(Inventory fromInv, InventorySlot sourceSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Backpack1.IsFilled()) return false;
        return SwapSlots(sourceSlot, fromInv.Backpack1);
    }

    private static bool ToBackpack2(Inventory fromInv, InventorySlot sourceSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Backpack2.IsFilled()) return false;
        return SwapSlots(sourceSlot, fromInv.Backpack2);
    }

    private static bool ToBackpack3(Inventory fromInv, InventorySlot sourceSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Backpack3.IsFilled()) return false;
        return SwapSlots(sourceSlot, fromInv.Backpack3);
    }

    private static bool ToBackpack4(Inventory fromInv, InventorySlot sourceSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Backpack4.IsFilled()) return false;
        return SwapSlots(sourceSlot, fromInv.Backpack4);
    }

    private static InventorySlot GetFreeSlot(Inventory fromInv)
    {
        InventorySlot result = fromInv.Backpack1;
        if (fromInv.Backpack1.IsFilled()) result = fromInv.Backpack2;
        if (fromInv.Backpack2.IsFilled()) result = fromInv.Backpack3;
        if (fromInv.Backpack3.IsFilled()) result = fromInv.Backpack4;
        if (fromInv.Backpack4.IsFilled()) result = null;
        return result;
    }
}
