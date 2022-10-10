using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class InventoryHelper
{
    public static bool Equip(Inventory fromInv, InventorySlot fromSlot, InventorySlot toSlot)
    {
        if (toSlot == fromInv.PrimaryItem) return EquipPrimaryItem(fromInv, fromSlot);
        if (toSlot == fromInv.Sidearm) return EquipSidearm(fromInv, fromSlot);
        if (toSlot == fromInv.Head) return EquipHead(fromInv, fromSlot);
        if (toSlot == fromInv.Torso) return EquipTorso(fromInv, fromSlot);
        return false;
    }

    private static bool EquipMainWeapon(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        Weapon newSource = fromSlot.Current as Weapon;
        if (!newSource) return false;
        return SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    private static bool EquipUsableItem(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        //UsableItem newSource = fromSlot.Current as UsableItem;
        //if (!newSource) return false;
        return SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    private static bool EquipPrimaryItem(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.PrimaryItem.IsFilled()) return false;
        return SwapSlots(fromSlot, fromInv.PrimaryItem);
    }

    private static bool EquipSidearm(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Sidearm.IsFilled()) return false;
        Weapon newSource = fromSlot.Current as Weapon;
        if (!newSource || !newSource.ItemData.IsSidearm) return false;
        return SwapSlots(fromSlot, fromInv.Sidearm);
    }

    private static bool EquipHead(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Head.IsFilled()) return false;
        //Wearable newSource = fromSlot.Current as Wearable;
        //if (!newSource || !newSource.IsHead) return false;
        return SwapSlots(fromSlot, fromInv.Head);
    }

    private static bool EquipTorso(Inventory fromInv, InventorySlot fromSlot, bool checkFilled = false)
    {
        if (checkFilled && fromInv.Torso.IsFilled()) return false;
        //Wearable newSource = fromSlot.Current as Wearable;
        //if (!newSource || newSource.IsHead) return false;
        return SwapSlots(fromSlot, fromInv.Torso);
    }
}
