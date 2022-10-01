using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventory : MonoBehaviour
{
    [Header("Equipment")]
    [SerializeField] private InventorySlot primaryItem;
    [SerializeField] private InventorySlot sidearm;
    [SerializeField] private InventorySlot head;
    [SerializeField] private InventorySlot torso;
    public InventorySlot PrimaryItem { get => primaryItem; private set => primaryItem = value; }
    public InventorySlot Sidearm { get => sidearm; private set => sidearm = value; }
    public InventorySlot Head { get => head; private set => head = value; }
    public InventorySlot Torso { get => torso; private set => torso = value; }

    public Weapon GetMainWeapon()
    {
        return GetPrimaryItem() as Weapon;
    }

    public UsableItem GetUsableItem()
    {
        return GetPrimaryItem() as UsableItem;
    }

    public Item GetPrimaryItem()
    {
        return PrimaryItem.Current;
    }

    public Weapon GetSidearm()
    {
        Weapon sidearm = Sidearm.Current as Weapon;
        bool isSidearm = sidearm && sidearm.IsSidearm;
        if (isSidearm) return sidearm;
        return null;
    }

    public bool Equip(InventorySlot from, InventorySlot to)
    {
        if (to == PrimaryItem) return EquipPrimaryItem(from);
        if (to == Sidearm) return EquipSidearm(from);
        if (to == Head) return EquipHead(from);
        if (to == Torso) return EquipTorso(from);
        return false;
    }
    
    private bool EquipMainWeapon(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && PrimaryItem.IsFilled()) return false;
        Weapon newSource = source.Current as Weapon;
        if (!newSource) return false;
        return SwapSlots(source, PrimaryItem);
    }

    private bool EquipUsableItem(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && PrimaryItem.IsFilled()) return false;
        UsableItem newSource = source.Current as UsableItem;
        if (!newSource) return false;
        return SwapSlots(source, PrimaryItem);
    }

    private bool EquipPrimaryItem(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && PrimaryItem.IsFilled()) return false;
        return SwapSlots(source, PrimaryItem);
    }

    private bool EquipSidearm(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Sidearm.IsFilled()) return false;
        Weapon newSource = source.Current as Weapon;
        if (!newSource || !newSource.IsSidearm) return false;
        return SwapSlots(source, Sidearm);
    }

    private bool EquipHead(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Head.IsFilled()) return false;
        Wearable newSource = source.Current as Wearable;
        if (!newSource || !newSource.IsHead) return false;
        return SwapSlots(source, Head);
    }

    private bool EquipTorso(InventorySlot source, bool checkFilled = false)
    {
        if (checkFilled && Torso.IsFilled()) return false;
        Wearable newSource = source.Current as Wearable;
        if (!newSource || newSource.IsHead) return false;
        return SwapSlots(source, Torso);
    }
}
