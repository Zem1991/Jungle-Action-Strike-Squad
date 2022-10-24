using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryEquipmentHelper
{
    public static bool Equip(Inventory fromInv, InventorySlot fromSlot, InventorySlot toSlot)
    {
        if (toSlot == fromInv.PrimaryItem) return EquipPrimaryItem(fromInv, fromSlot);
        if (toSlot == fromInv.Sidearm) return EquipSidearm(fromInv, fromSlot);
        if (toSlot == fromInv.Head) return EquipHead(fromInv, fromSlot);
        if (toSlot == fromInv.Torso) return EquipTorso(fromInv, fromSlot);
        return false;
    }

    public static bool EquipMainWeapon(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        Weapon newSource = fromSlot.Current as Weapon;
        if (!newSource) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    public static bool EquipTool(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        Tool newSource = fromSlot.Current as Tool;
        if (!newSource) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    public static bool EquipPrimaryItem(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    public static bool EquipSidearm(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Sidearm.IsFilled()) return false;
        Weapon newSource = fromSlot.Current as Weapon;
        if (!newSource || !newSource.ItemData.IsSidearm) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.Sidearm);
    }

    public static bool EquipHead(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Head.IsFilled()) return false;
        Wearable newSource = fromSlot.Current as Wearable;
        if (!newSource || newSource.ItemData.IsHead) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.Head);
    }

    public static bool EquipTorso(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Torso.IsFilled()) return false;
        Wearable newSource = fromSlot.Current as Wearable;
        if (!newSource || !newSource.ItemData.IsHead) return false;
        return InventoryOperationsHelper.SwapSlots(fromSlot, fromInv.Torso);
    }
}
