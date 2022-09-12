using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventory : MonoBehaviour
{
    private bool SwapSlots(InventorySlot from, InventorySlot to)
    {
        from.Remove(out Item itemFrom);
        to.Remove(out Item itemTo);
        bool fromAccepts = !itemTo || from.Accepts(itemTo);
        bool toAccepts = !itemFrom || to.Accepts(itemFrom);
        if (fromAccepts && toAccepts)
        {
            from.Add(itemTo);
            to.Add(itemFrom);
            return true;
        }
        else
        {
            from.Add(itemFrom);
            to.Add(itemTo);
            return false;
        }
    }
}
