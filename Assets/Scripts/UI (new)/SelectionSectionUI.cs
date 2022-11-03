using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SelectionSectionUI : UIDropdownPanel<AbilityInstance, AbilityInstanceUI>, IPointerClickHandler, IPointerExitHandler
{
    [Header("SelectionSectionUI Awake")]
    [SerializeField] protected VerticalLayoutGroup verticalLayoutGroup;

    [Header("SelectionSectionUI Runtime")]
    [SerializeField] private Character character;
    public Character Character { get => character; private set => character = value; }

    protected override void Awake()
    {
        base.Awake();
        verticalLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>();
    }

    public override void Refresh()
    {
        Character = SelectionController.Instance.Get();
        if (Character) Show();
        else Hide();
    }

    protected override List<AbilityInstance> GetSourceList()
    {
        AbilitySet characterAbilitySet = GetAbilitySet();
        return characterAbilitySet.GetAllIndexed().Values.ToList();
    }

    protected override AbilityInstanceUI InitializeUIObject(AbilityInstance source)
    {
        AbilityInstanceUI result = UIPrefabs.Instance.Instantiate(source, verticalLayoutGroup.transform);
        return result;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenDropdown();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CloseDropdown();
    }

    protected abstract AbilitySet GetAbilitySet();
}
