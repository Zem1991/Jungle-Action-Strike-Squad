using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReloadHelper
{
    public static Ammunition FindAmmo(Character actor, RangedWeapon rangedWeapon)
    {
        Inventory inventory = actor.Inventory;
        AmmunitionType ammunitionType = rangedWeapon.ItemData.DefaultAmmo.Type;
        Ammunition currentAmmo = rangedWeapon.CurrentAmmunition;
        AmmunitionData currentAmmoData = currentAmmo?.ItemData;

        List<InventorySlot> ammoSlots = InventorySearchHelper.FindAmmo(inventory, ammunitionType, currentAmmoData);
        if (ammoSlots.Count <= 0) return null;

        InventorySlot nextAmmoSlot = ammoSlots[0];
        Ammunition result = ExchangeFromInventory(rangedWeapon, nextAmmoSlot);
        return result;
    }

    private static Ammunition ExchangeFromInventory(RangedWeapon rangedWeapon, InventorySlot ammoSlot)
    {
        Ammunition ammoFromSlot = ammoSlot.Current as Ammunition;
        Resource ammoStackFromSlot = ammoFromSlot.Stack;

        Ammunition ammoFromWeapon = rangedWeapon.CurrentAmmunition;
        if (!ammoFromWeapon)
        {
            ammoFromWeapon = Object.Instantiate(ammoFromSlot, ammoFromSlot.transform.parent);
            ammoFromWeapon.Initialize(ammoFromSlot.ItemData);
            ammoFromWeapon.Stack.MakeEmpty();
        }
        Resource ammoStackFromWeapon = ammoFromWeapon.Stack;

        int ammoOnWeapon = ammoStackFromWeapon.Current;
        int ammoOnSlot = ammoStackFromSlot.Current;

        int magazineSize = rangedWeapon.ItemData.MagazineSize;
        int ammoToTransfer = magazineSize - ammoOnWeapon;
        
        int slotAmmoRemaining = ammoOnSlot - ammoToTransfer;
        if (slotAmmoRemaining < 0)
        {
            ammoToTransfer += slotAmmoRemaining;
        }

        ammoStackFromSlot.Subtract(ammoToTransfer);
        ammoStackFromWeapon.Add(ammoToTransfer);

        if (ammoStackFromSlot.CheckEmpty())
        {
            ammoSlot.Remove(out Item itemFromSlot);
            Object.Destroy(itemFromSlot.gameObject);
        }

        return ammoFromWeapon;
    }
}
