using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class InventorySlotUI : UIPanel, IPointerEnterHandler, IPointerExitHandler//, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryController.Instance.OnPointerEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryController.Instance.OnPointerExit(this);
    }

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    EventController eventController = EventController.Instance;
    //    bool equipped = inventory.Equip(slot, eventController.InventorySlotPointerEnter.slot);
    //    if (!equipped) inventory.Pack(slot, eventController.InventorySlotPointerEnter.slot);
    //    eventController.OnPointerUp();
    //}
}
