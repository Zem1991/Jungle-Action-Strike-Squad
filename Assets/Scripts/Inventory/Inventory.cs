using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventory : MonoBehaviour
{
    private void Awake()
    {
        PrimaryItem = new InventorySlot(typeof(Item));
        Sidearm = new InventorySlot(typeof(Weapon));
        Head = new InventorySlot(typeof(Wearable));
        Torso = new InventorySlot(typeof(Wearable));
        Backpack1 = new InventorySlot(typeof(Item));
        Backpack2 = new InventorySlot(typeof(Item));
        Backpack3 = new InventorySlot(typeof(Item));
        Backpack4 = new InventorySlot(typeof(Item));

        Item[] items = GetComponentsInChildren<Item>();
        foreach (Item item in items)
        {
            bool added = Add(item);
            if (!added)
            {
                Debug.LogWarning($"Some character had too many items during its Awake call. {item.ItemName} got destroyed.");
                Destroy(item);
            }
        }
    }

    public bool Add(Item item)
    {
        bool result = false;
        InventorySlot tempSlot = new InventorySlot(typeof(Item), item);
        if (EquipMainWeapon(tempSlot, true)) result = true;
        else if (EquipUsableItem(tempSlot, true)) result = true;
        else if (EquipSidearm(tempSlot, true)) result = true;
        else if (EquipTorso(tempSlot, true)) result = true;
        else if (EquipHead(tempSlot, true)) result = true;
        else if (ToBackpackFree(tempSlot)) result = true;
        else if (EquipPrimaryItem(tempSlot, true)) result = true;
        //if (result) item.transform.parent = transform;
        return result;
    }

    public bool Remove(InventorySlot slot, out Item item)
    {
        bool removed = slot.Remove(out item);
        //if (removed) item.transform.parent = null;
        return removed;
    }
}
