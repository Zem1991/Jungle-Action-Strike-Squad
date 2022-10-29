using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityButtonUI : UIPanel, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("AbilityButtonUI Awake")]
    [SerializeField] private AbilitySpriteUI spriteUI;

    [Header("AbilityButtonUI Runtime")]
    [SerializeField] private AbilityInstance ability;

    protected override void Awake()
    {
        base.Awake();
        spriteUI = GetComponentInChildren<AbilitySpriteUI>();
    }

    public override void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.2F;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerExit(null);
        AbilityController.Instance.Set(ability, false);
    }

    public void Refresh(AbilityInstance ability)
    {
        this.ability = ability;
        spriteUI.Refresh(ability);
        if (ability != null)
            Show();
        else
            Hide();
    }
}
