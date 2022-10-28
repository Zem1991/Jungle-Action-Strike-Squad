using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryUI : UIPanel
{
    public override void Refresh()
    {
        CommandController actionController = CommandController.Instance;
        if (actionController.HasCurrent())
        {
            Hide();
            return;
        }

        Character character = InventoryController.Instance.Current;
        if (character)
        {
            RefreshData(character);
            RefreshSlots(character);
            character.RefreshAbilitys();
            Show();
        }
        else
        {
            Hide();
        }
    }

    //public void Refresh(Character character)
    //{
    //    if (!character) return;
    //    Character = character;
    //    Refresh();
    //}

    public void Swap(InventorySlotUI from, InventorySlotUI to)
    {
        Character character = InventoryController.Instance.Current;
        character.Inventory.Swap(from.Slot, to.Slot);
        Refresh();
    }
}
