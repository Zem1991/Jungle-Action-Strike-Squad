using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InventoryItemUI : UIPanel
{
    [Header("Data")]
    [SerializeField] private Vector2 localOrigin;
    [SerializeField] private InventorySlotUI slotUI;
    public Vector2 LocalOrigin { get => localOrigin; private set => localOrigin = value; }
    public InventorySlotUI SlotUI { get => slotUI; private set => slotUI = value; }

    public void Refresh(InventorySlotUI slotUI, Item item)
    {
        SlotUI = slotUI;
        if (item)
        {
            itemSprite.sprite = item.ItemData.Sprite;
            itemSprite.enabled = true;
        }
        else
        {
            itemSprite.sprite = null;
            itemSprite.enabled = false;
        }
    }
}
