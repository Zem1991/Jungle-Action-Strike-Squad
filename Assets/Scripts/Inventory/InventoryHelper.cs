using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class InventoryHelper
{
    public static bool Add(Inventory fromInv, Item item)
    {
        bool result = false;
        InventorySlot tempSlot = new InventorySlot(typeof(Item), item);
        if (EquipMainWeapon(fromInv, tempSlot, true)) result = true;
        else if (EquipUsableItem(fromInv, tempSlot, true)) result = true;
        else if (EquipSidearm(fromInv, tempSlot, true)) result = true;
        else if (EquipTorso(fromInv, tempSlot, true)) result = true;
        else if (EquipHead(fromInv, tempSlot, true)) result = true;
        else if (ToBackpackFree(fromInv, tempSlot)) result = true;
        else if (EquipPrimaryItem(fromInv, tempSlot, true)) result = true;
        //if (result) item.transform.parent = transform;
        return result;
    }

    public static bool Remove(Inventory fromInv, InventorySlot fromSlot, out Item item)
    {
        bool removed = fromSlot.Remove(out item);
        //if (removed) item.transform.parent = null;
        return removed;
    }

    public static bool Swap(Inventory fromInv, InventorySlot fromSlot, InventorySlot toSlot)
    {
        bool result = Equip(fromInv, fromSlot, toSlot);
        if (!result) result = Pack(fromInv, fromSlot, toSlot);
        return result;
    }

    private static bool SwapSlots(InventorySlot fromSlot, InventorySlot toSlot)
    {
        fromSlot.Remove(out Item itemFrom);
        toSlot.Remove(out Item itemTo);
        bool fromAccepts = !itemTo || fromSlot.Accepts(itemTo);
        bool toAccepts = !itemFrom || toSlot.Accepts(itemFrom);
        if (fromAccepts && toAccepts)
        {
            fromSlot.Add(itemTo);
            toSlot.Add(itemFrom);
            return true;
        }
        else
        {
            fromSlot.Add(itemFrom);
            toSlot.Add(itemTo);
            return false;
        }
    }
}
