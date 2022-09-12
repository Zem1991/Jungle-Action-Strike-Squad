using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryUI : UIPanel
{
    public override void Refresh()
    {
        ActionController actionController = ActionController.Instance;
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
            character.RefreshCommands();
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
        bool equipped = character.Inventory.Equip(from.Slot, to.Slot);
        if (!equipped) character.Inventory.Pack(from.Slot, to.Slot);
        Refresh();
    }
}
