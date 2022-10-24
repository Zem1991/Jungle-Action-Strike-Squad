using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryOperationsHelper
{
    public static bool Add(Inventory fromInv, Item item)
    {
        if (!item) return false;
        bool result = false;
        InventorySlot tempSlot = new InventorySlot(typeof(Item), item);
        if (InventoryEquipmentHelper.EquipMainWeapon(fromInv, tempSlot, true)) result = true;
        else if (InventoryEquipmentHelper.EquipTool(fromInv, tempSlot, true)) result = true;
        else if (InventoryEquipmentHelper.EquipSidearm(fromInv, tempSlot, true)) result = true;
        else if (InventoryEquipmentHelper.EquipHead(fromInv, tempSlot, true)) result = true;
        else if (InventoryEquipmentHelper.EquipTorso(fromInv, tempSlot, true)) result = true;
        else if (InventoryBackpackHelper.Pack(fromInv, tempSlot)) result = true;
        else if (InventoryEquipmentHelper.EquipPrimaryItem(fromInv, tempSlot, true)) result = true;
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
        bool result = InventoryEquipmentHelper.Equip(fromInv, fromSlot, toSlot);
        if (!result) result = InventoryBackpackHelper.Pack(fromInv, fromSlot, toSlot);
        return result;
    }

    public static bool SwapSlots(InventorySlot fromSlot, InventorySlot toSlot)
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
