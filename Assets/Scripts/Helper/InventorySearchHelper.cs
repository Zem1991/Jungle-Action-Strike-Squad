using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class InventorySearchHelper
{
    public static List<InventorySlot> FindAmmo(Inventory inventory, AmmunitionType ammunitionType, AmmunitionData currentAmmoData = null)
    {
        List<InventorySlot> slots = InventoryBackpackHelper.GetBackpackSlots(inventory);
        List<InventorySlot> ammos = new List<InventorySlot>();
        foreach (InventorySlot slot in slots)
        {
            Ammunition slotAmmo = slot.Current as Ammunition;
            if (!slotAmmo) continue;
            if (slotAmmo.ItemData.Type != ammunitionType) continue;
            ammos.Add(slot);
        }

        List<InventorySlot> result = ammos.OrderBy(item => (item.Current as Ammunition).ItemData == currentAmmoData).ToList();
        return result;
    }
}
