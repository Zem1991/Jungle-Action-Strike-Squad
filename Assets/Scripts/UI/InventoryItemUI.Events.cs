using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class InventoryItemUI : UIPanel, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryController.Instance.OnBeginDrag(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!SlotUI.IsFilled()) return;
        Vector3 position = CursorController.Instance.ScreenPosition;
        SetSpriteDrag(position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        InventoryController.Instance.OnEndDrag(this);
        ResetSpriteDrag();
    }
}
