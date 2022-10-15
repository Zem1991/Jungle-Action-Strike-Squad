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

    [Header("Backpack")]
    [SerializeField] private InventorySlot backpack1;
    [SerializeField] private InventorySlot backpack2;
    [SerializeField] private InventorySlot backpack3;
    [SerializeField] private InventorySlot backpack4;
    public InventorySlot Backpack1 { get => backpack1; private set => backpack1 = value; }
    public InventorySlot Backpack2 { get => backpack2; private set => backpack2 = value; }
    public InventorySlot Backpack3 { get => backpack3; private set => backpack3 = value; }
    public InventorySlot Backpack4 { get => backpack4; private set => backpack4 = value; }

    private void Awake()
    {
        InitializeSlots();
        InitializeItems();
    }

    private void InitializeSlots()
    {
        PrimaryItem = new InventorySlot(typeof(Item));
        Sidearm = new InventorySlot(typeof(Weapon));
        Head = new InventorySlot(typeof(Item));
        Torso = new InventorySlot(typeof(Item));
        //Head = new InventorySlot(typeof(Wearable));
        //Torso = new InventorySlot(typeof(Wearable));

        Backpack1 = new InventorySlot(typeof(Item));
        Backpack2 = new InventorySlot(typeof(Item));
        Backpack3 = new InventorySlot(typeof(Item));
        Backpack4 = new InventorySlot(typeof(Item));
    }

    private void InitializeItems()
    {
        Item[] items = GetComponentsInChildren<Item>();
        foreach (Item item in items)
        {
            bool added = InventoryOperationsHelper.Add(this, item);
            if (!added)
            {
                Debug.LogWarning($"Some character had too many items during its Initialization. An {item.ItemData.Name} got destroyed.");
                Destroy(item);
            }
        }
    }

    public bool Add(Item item)
    {
        return InventoryOperationsHelper.Add(this, item);
    }

    public bool Remove(InventorySlot slot, out Item item)
    {
        return InventoryOperationsHelper.Remove(this, slot, out item);
    }

    public bool Swap(InventorySlot fromSlot, InventorySlot toSlot)
    {
        return InventoryOperationsHelper.Swap(this, fromSlot, toSlot);
    }
}
