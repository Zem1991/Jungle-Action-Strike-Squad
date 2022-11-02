using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SelectionSectionUI : UIDropdownPanel<AbilityInstance, AbilityInstanceUI>
{
    [Header("SelectionSectionUI Runtime")]
    [SerializeField] private Character character;
    public Character Character { get => character; private set => character = value; }

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
        AbilityInstanceUI result = UIPrefabs.Instance.Instantiate(source);
        return result;
    }

    protected abstract AbilitySet GetAbilitySet();
}
