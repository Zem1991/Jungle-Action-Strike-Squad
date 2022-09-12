using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButtonUI : UIPanel, IPointerClickHandler
{
    [Header("Scene")]
    [SerializeField] private Image sprite;
    
    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //PlayerController.Instance.ToggleInventory();
    }
    
    public void Refresh(Character character)
    {
        //InventorySlot slot = character.Inventory.PrimaryItem;
        //Item item = slot.Current;
        //if (item)
        //{
        //    itemSprite.sprite = item.ItemSprite;
        //    itemSprite.enabled = true;
        //}
        //else
        //{
        //    itemSprite.sprite = null;
        //    itemSprite.enabled = false;
        //}
    }
}
