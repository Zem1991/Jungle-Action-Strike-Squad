using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityInstanceUI : UIPanel, IPointerClickHandler
{
    [Header("Scene")]
    [SerializeField] private AbilityBasicsUI abilityBasics;
    [SerializeField] private ItemSpriteUI itemSpriteUI;

    [Header("Runtime")]
    [SerializeField] private AbilityInstance ability = null;

    protected override void Awake()
    {
        base.Awake();

        abilityBasics = GetComponentInChildren<AbilityBasicsUI>();
        itemSpriteUI = GetComponentInChildren<ItemSpriteUI>();

        ////Fix for Serialization creating empty objects instead of null objects
        //ability = null;
    }

    public override void Refresh()
    {
        //if (ability == null)
        //{
        //    Hide();
        //    return;
        //}

        abilityBasics.Refresh(ability);
        itemSpriteUI.Refresh(ability.Item);

        //Show();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AbilityController.Instance.Set(ability, false);
    }

    public void Initialize(AbilityInstance abilityInstance)
    {
        ability = abilityInstance;
        Refresh();
    }
}
