using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private Inventory inventory;
    public Inventory Inventory { get => inventory; private set => inventory = value; }

    public Weapon GetMainWeapon()
    {
        return Inventory.GetMainWeapon();
    }

    public Tool GetUsableItem()
    {
        return Inventory.GetTool();
    }

    public Item GetPrimaryItem()
    {
        return Inventory.GetPrimaryItem();
    }

    public Weapon GetSidearm()
    {
        return Inventory.GetSidearm();
    }
}
