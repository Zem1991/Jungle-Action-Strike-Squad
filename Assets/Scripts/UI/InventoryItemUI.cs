using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class InventoryItemUI : UIPanel
{
    [Header("Self references")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image itemSprite;

    protected override void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        itemSprite = GetComponent<Image>();
        LocalOrigin = transform.localPosition;
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    private void SetSpriteDrag(Vector3 position)
    {
        transform.SetParent(canvas.transform);
        transform.position = position;
        itemSprite.raycastTarget = false;
    }

    private void ResetSpriteDrag()
    {
        transform.SetParent(SlotUI.transform);
        transform.localPosition = LocalOrigin;
        itemSprite.raycastTarget = true;
    }
}
