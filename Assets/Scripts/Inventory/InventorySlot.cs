using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    private Type type;
    [SerializeField] private Item current;
    public Type Type { get => type; set => type = value; }
    public Item Current { get => current; set => current = value; }

    public InventorySlot(Type slotType, Item current = null)
    {
        Type = slotType;
        Current = current;
    }

    public bool IsFilled()
    {
        return Current;
    }

    public bool Accepts(Item item)
    {
        if (!item) return false;
        Type itemType = item.GetType();
        bool sameType = itemType == Type;
        bool subclass = itemType.IsSubclassOf(Type);
        return sameType || subclass;
    }

    public bool Add(Item item)
    {
        if (IsFilled() || !Accepts(item))
        {
            return false;
        }
        else
        {
            Current = item;
            return true;
        }
    }

    public bool Remove(out Item item)
    {
        if (IsFilled())
        {
            item = Current;
            Current = null;
            return true;
        }
        else
        {
            item = null;
            return false;
        }
    }
}
